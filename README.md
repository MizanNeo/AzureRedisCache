# AzureRedisCache in ASP.NET Core Web API
## Overview
* Caching is the process of storing copies of files or data in a cache, or temporary storage location, so that they can be accessed more quickly. It is the process of storing data or files in a temporary storage for a specific period, so that from the next time onwards, when the data is requested, it can be provided from this temporary storage instead of database or from original files.
* A distributed cache is a cache shared by multiple application servers. Distributed cache improves application performance and scalability because it can supply the same data to multiple servers consistently and if one server restarts or crashes, the cached data is still available to other servers as normal. 
Created Redis cache in Azure portal. Use nuget package and connection string to store department data on Azure Redis cache.
### Distributed Caching in ASP.NET Core 6.0 
IDistributedCache Interface provides you with the following methods to perform actions on the actual cache. 
* Get, GetAsync - Gets the value from the cache server based on the string key. These methods accept a key and retrieve a cached item as a byte [] array. 
* Set, SetAsync - Accepts a string key and value and sets it to the cache server. These methods add an item (as byte [] array) to the cache using a key. 
* Refresh, RefreshAsync - Resets the sliding expiration timeout. These methods are used to refresh an item in the cache based on its key, resetting its sliding expiration timeout. 
* Remove, RemoveAsync – Removes the cache data based on the string key.
  
To use distributed cache in ASP.NET Core, we have multiple built-in and third-party implementations to choose from.  
* Distributed SQL Server cache - To use a SQL Server distributed cache, we need to use this package. 
* Distributed Redis cache - To use a Redis distributed cache, we need to use this package. 
* Distributed NCache cache - To use NCache distributed cache, we need to use this package.

### What is Redis Cache 
Redis is an open source (BSD licensed), in-memory data structure store used as a database, cache, message broker, and streaming engine. Redis provides data structures such as strings, hashes, lists, sets, sorted sets with range queries, bitmaps, hyperloglogs, geospatial indexes, and streams. Redis has built-in replication, Lua scripting, LRU eviction, transactions, and various levels of on-disk persistence, and provides high availability via Redis Sentinel and automatic partitioning with Redis Cluster. 

You can use Redis in many programming languages. It is such a popular and widely used cache that Microsoft Azure also provides its cloud-based version with the name Azure Cache for Redis. 
### Steps to implement Azure Redis Cache in ASP.NET Core Web API project.
1. Install Nuget package- Microsoft.Extensions.Caching.StackExchangeRedis
2. Add Redis server connection string in AppSetting.json
   
    "ConnectionStrings": {
      "MyAzureRedisConStr": "d.redis.cache.windows.net:6380,password=L4f1ipjCvVmleiab9AvAOr9mFu3SQKpY2AzCaJF1clU=,ssl=True,abortConnect=False"
    }
   
3. Add Redis distributed caching services into service container in program.cs
   
    builder.Services.AddStackExchangeRedisCache(options => {
     options.Configuration = builder.Configuration.GetConnectionString("MyAzureRedisConStr");
    });
   
4. Inject IDistributedCache, Use GetAsync() and SetAsync() of IDistributedCache object.
   
    var cachedDepartments = await cache.GetAsync("CachedDepartments");
    if (cachedDepartments != null)
    {
        return Ok(JsonSerializer.Deserialize<IEnumerable<Department>>(cachedDepartments));
    }
    else
    {
        var result= await mediator.Send(new GetDepartmentListQuery());
        await cache.SetAsync("CachedDepartments", JsonSerializer.SerializeToUtf8Bytes(result), new           DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(config.GetValue<double>("RedisCache:SlidingExpirationMinutes"))));
        return Ok(result);
    }
  
