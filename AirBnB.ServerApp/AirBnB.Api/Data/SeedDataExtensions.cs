using AirBnB.Domain.Entities;
using AirBnB.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AirBnB.Api.Data;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedAsync(this IServiceProvider serviceProvider)
    {
        var locationsDbContext = serviceProvider.GetRequiredService<AirBnBdbContext>();
        var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();

           if (!await locationsDbContext.LocationCategories.AnyAsync())
               await locationsDbContext.SeedLocationCategoryAsync(environment);
        
          if (!await locationsDbContext.Locations.AnyAsync())
            await locationsDbContext.SeedLocationsAsync();
    }
    
    private static async ValueTask SeedLocationsAsync(this AirBnBdbContext airBnBdbContext)
    {
        
        var imageList = new List<string>
        {
            "https://a0.muscache.com/im/pictures/53ed423f-f4c4-4be5-9bf9-e52861167c0f.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-832355501498041527/original/551de2c9-6981-4222-b21d-75dd8792bd2d.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-44265625/original/f3a34292-ea0d-4614-9089-3b2ed382e7f5.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/16741847/6cdb4377_original.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-883697523223642736/original/57d9cca1-3ddd-43a6-ad0b-1178f1518dcb.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-798310927368521545/original/da546e7a-df43-4840-9144-5e1a8b85bf26.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-853189955208971108/original/bdefcb9d-5e3f-495d-bc04-013125cd99c6.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-1025798788809925759/original/cc9cc97e-ffef-4606-8b5b-1175f0e660ae.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/a1314224-52d7-4e3c-9c85-8fbdb5644ec5.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-876463172459170480/original/60963c66-9a75-4424-bcd7-d5a02080a45d.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/0c3e645b-2c70-426f-bf0c-c45968e8b69f.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/74fc010b-e809-42ff-a1ee-d58bc4cfd202.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-980193538711664916/original/7751128a-f0b7-4f67-95e7-ef3ee3b79ccf.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-603281858277532903/original/92af7b7e-0b55-41f4-b4a7-ffab7ee6125d.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-45789576/original/8909a57c-c10f-43ae-a40e-6651825650fc.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/6bdb2982-cfce-4caf-87d4-a45371cd8934.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-52735288/original/183c7db9-f3a7-4aa3-83b2-13582bf462a5.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/prohost-api/Hosting-670117968238504494/original/1eb90d31-9d0b-4879-bf8b-d76e8ccf2705.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-50545526/original/af14ce0b-481e-41be-88d1-b84758f578e5.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/181d4be2-6cb2-4306-94bf-89aa45c5de66.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/5ca08dcc-88d9-4e8b-b1c5-ff0fde50f03e.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/be5ec43d-245a-4c09-9bb7-a5e1b8eb56b3.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-759790852861911349/original/1af736a3-de22-4c2a-9a0b-1b6eaac7f7e6.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/c0e10c8f-d0c3-4875-bae8-0f664a55bbc6.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-852899544635683289/original/c627f47e-8ca9-4471-90d4-1fd987dd2362.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-40792948/original/f603aac0-729b-41e0-932a-823c27142204.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/177ed8a7-557b-480f-8319-4f8330e2c692.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-696847375839509250/original/9686a3bd-dfff-4ae6-bb51-514154308bdb.png?im_w=720",
            "https://a0.muscache.com/im/pictures/d933756f-8be4-4e82-b660-fd99cb7ebc07.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/prohost-api/Hosting-716713792374148221/original/569f0d50-fae8-4b9f-a426-1c810fb64a64.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/27122e63-4782-4cf7-946c-692d37964133.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/hosting/Hosting-947792708301617564/original/dc7f94ec-ae2a-4e04-8ccc-6e4705a5484f.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/54fa4470-f6f3-4475-87c3-3cb4673c125e.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/e61e0ed7-7007-4689-8003-d45751f0e073.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-49957679/original/9d7b73f6-472f-41f7-bb0d-e0aff3cab3be.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/prohost-api/Hosting-850002661541201574/original/96c78b9b-cd02-480f-ba0a-39bc9c96da87.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/7dd3d8ea-5a47-46d0-9091-28c88635d2d1.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-717252861094581767/original/452d9c8d-0af3-4e39-8e33-37a07cb8cbbf.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-1022472381276201609/original/0fa1d087-4d28-4407-a90a-51a1b0014cb3.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-846237006139467287/original/bbd1c97f-5431-4e8f-981f-f1ff6ac2a97f.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/0c68bd94-f471-4bc8-9c37-9eb78c2628e8.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-789655605011323416/original/f1681747-4c10-4a1c-bf8a-3a0c88e0ffbd.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/96cedf05-0b8c-4f65-9f80-d65d66104d2e.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/prohost-api/Hosting-908368503013487975/original/43ad2b5a-b783-47fc-86ad-4949b2a53193.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/f382147c-f68c-4dda-b810-87a4de82f5a7.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/b271226e-9453-4d73-aac0-1622550b08e4.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/30d6cf52-d303-4026-8d8c-5cc8ac03444e.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/f042c16f-dde9-436e-96a0-9c21ab7da2d0.jpg?im_w=720"
        };
        var categoryIdList = new List<string>
        {   
            "7593fb46-91a0-4d93-a04f-07580a25b8d8",
        };
        var count = 0;
        var random = new Random();

        foreach (var imageUrl in imageList)
        {
            await airBnBdbContext.Locations.AddAsync(new Location
        {
            ImageUrl = imageUrl,
            Name = "Bujra. India Bujra. India Bujra. India Bujra. India Bujra. India Bujra. IndiaBujra. IndiaBujra. India",
            BuiltYear = random.Next(2010, 2023),
            PricePerNight = random.Next(300, 5000),
            CategoryId = Guid.Parse("7593fb46-91a0-4d93-a04f-07580a25b8d8")
        }); 
        
        await airBnBdbContext.SaveChangesAsync();
        }
        
    }

    private static async ValueTask SeedLocationCategoryAsync(this AirBnBdbContext airBnBdbContext, IWebHostEnvironment environment)
    {
        var locationCategories = JsonConvert.DeserializeObject<List<LocationCategory>>(await File.ReadAllTextAsync(
            Path.Combine(environment.ContentRootPath, "Data", "SeedData", "ListingCategories.json")))!;
        
        /*
        imagePathDictionary.Add("Castle","Assets/LocationCotegories/1b6a8b70-a3b6-48b5-88e1-2243d9172c06.jpg");
        imagePathDictionary.Add("Amazing views","Assets/LocationCotegories/3b1eb541-46d9-4bef-abc4-c37d77e3c21b.jpg");
        imagePathDictionary.Add("Amazing pools","Assets/LocationCotegories/3fb523a0-b622-4368-8142-b5e03df7549b.jpg");
        imagePathDictionary.Add("Riads","Assets/LocationCotegories/7ff6e4a1-51b4-4671-bc9a-6f523f196c61.jpg");
        imagePathDictionary.Add("Arctic","Assets/LocationCotegories/8b44f770-7156-4c7b-b4d3-d92549c8652f.jpg");
        imagePathDictionary.Add("Islands","Assets/LocationCotegories/8e507f16-4943-4be9-b707-59bd38d56309.jpg");
        imagePathDictionary.Add("Cases particulares","Assets/LocationCotegories/251c0635-cc91-4ef7-bb13-1084d5229446.jpg");
        imagePathDictionary.Add("Shepherd's huts","Assets/LocationCotegories/747b326c-cb8f-41cf-a7f9-809ab646e10c.jpg");
        imagePathDictionary.Add("Yurts","Assets/LocationCotegories/4759a0a7-96a8-4dcd-9490-ed785af6df14.jpg");
        imagePathDictionary.Add("Trulli","Assets/LocationCotegories/33848f9e-8dd6-4777-b905-ed38342bacb9.jpg");
        imagePathDictionary.Add("Desert","Assets/LocationCotegories/a6dd2bae-5fd0-4b28-b123-206783b5de1d.jpg");
        imagePathDictionary.Add("Dammusi","Assets/LocationCotegories/c9157d0a-98fe-4516-af81-44022118fbc7.jpg");
        imagePathDictionary.Add("Earth homes","Assets/LocationCotegories/d7445031-62c4-46d0-91c3-4f29f9790f7a.jpg");
        imagePathDictionary.Add("Cucladic homes","Assets/LocationCotegories/e4b12c1b-409b-4cb6-a674-7c1284449f6e.jpg");
        imagePathDictionary.Add("Adepted","Assets/LocationCotegories/e22b0816-f0f3-42a0-a5db-e0f1fa93292b.jpg");
        /*imagePathDictionary.Add("","Assets/LocationCotegories/5cdb8451-8f75-4c5f-a17d-33ee228e3db8.jpg");
        imagePathDictionary.Add("","Assets/LocationCotegories/7ff6e4a1-51b4-4671-bc9a-6f523f196c61.jpg");
        imagePathDictionary.Add("","Assets/LocationCotegories/f0c5ca0f-5aa0-4fe5-b38d-654264bacddf.jpg");
        imagePathDictionary.Add("","Assets/LocationCotegories/e22b0816-f0f3-42a0-a5db-e0f1fa93292b.jpg");
        imagePathDictionary.Add("","Assets/LocationCotegories/89faf9ae-bbbc-4bc4-aecd-cc15bf36cbca.jpg");
        imagePathDictionary.Add("","Assets/LocationCotegories/827c5623-d182-474a-823c-db3894490896.jpg");
        imagePathDictionary.Add("","Assets/LocationCotegories/9a2ca4df-ee90-4063-b15d-0de7e4ce210a.jpg");
        imagePathDictionary.Add("","Assets/LocationCotegories/d721318f-4752-417d-b4fa-77da3cbc3269.jpg");
        imagePathDictionary.Add("","Assets/LocationCotegories/c9157d0a-98fe-4516-af81-44022118fbc7.jpg"); */

        await airBnBdbContext.AddRangeAsync(locationCategories);
        await airBnBdbContext.SaveChangesAsync();
        
        /*foreach (var (key, value) in imagePathDictionary)
        {
            await airBnBdbContext.LocationCategories.AddAsync(new LocationCategory
            {
                Name = key,
                ImagePath = value 
            });

            await airBnBdbContext.SaveChangesAsync();
        }*/
    }
}