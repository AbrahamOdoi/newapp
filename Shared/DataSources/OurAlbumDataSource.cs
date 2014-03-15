using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class OurAlbumDataSource : IDataSource<OurAlbumSchema>
    {
        private readonly IEnumerable<OurAlbumSchema> _data = new OurAlbumSchema[]
		{
            new OurAlbumSchema
            {
                Id = "{4ebd5657-cb99-4a10-bc61-afb853aaefe5}",
                Title = "Photo 01",
                Subtitle = "Photo 01",
                Image = "/Assets/DataImages/mee.jpg",
                Description = "Photo 01",
            },
            new OurAlbumSchema
            {
                Id = "{ea829690-95ed-452f-b962-534e1226fea6}",
                Title = "Photo 02",
                Subtitle = "Photo 02",
                Image = "/Assets/DataImages/avatar.jpg",
                Description = "Photo 02",
            },
            new OurAlbumSchema
            {
                Id = "{3929a028-99f0-4d59-ab14-07e70ac37856}",
                Title = "Photo 03",
                Subtitle = "Photo 03",
                Image = "/Assets/DataImages/img-20130928-wa0001.jpg",
                Description = "Photo 03",
            },
            new OurAlbumSchema
            {
                Id = "{1290e353-6aa0-4274-a8e5-ab6d6a1b0663}",
                Title = "Photo 04",
                Subtitle = "Photo 04",
                Image = "/Assets/DataImages/Item-b34ca868-1b36-4137-883b-d9796fe6e71c.jpg",
                Description = "Photo 04",
            },
            new OurAlbumSchema
            {
                Id = "{c723c650-df73-456f-887e-1a79d6e54b31}",
                Title = "Photo 05",
                Subtitle = "Photo 05",
                Image = "/Assets/DataImages/Item-c08e3fa7-a8e6-4df3-9e47-fa59b19cbeee.png",
                Description = "Photo 05",
            },
            new OurAlbumSchema
            {
                Id = "{c0753dd2-aba3-4ed7-b31e-30c397638a9c}",
                Title = "Photo 06",
                Subtitle = "Photo 06",
                Image = "/Assets/DataImages/Item-b1b68a15-f6bf-4484-852e-45556c09d24d.png",
                Description = "Photo 06",
            },
            new OurAlbumSchema
            {
                Id = "{9ac70f2b-36dd-4234-a1cb-2a3eb25d4896}",
                Title = "Photo 07",
                Subtitle = "Photo 07",
                Image = "/Assets/DataImages/Item-cce977a6-4ed9-4f5a-962d-ef6744c252f2.jpg",
                Description = "Photo 07",
            },
            new OurAlbumSchema
            {
                Id = "{04cfe4a4-2bb9-4a62-9ad8-a4249104339e}",
                Title = "Photo 08",
                Subtitle = "Photo 08",
                Image = "/Assets/DataImages/Item-369ada88-95bc-45fd-87e7-072c0c1b9895.jpg",
                Description = "Photo 08",
            },
            new OurAlbumSchema
            {
                Id = "{b20f5321-2585-49ee-8b83-3d1af5be9bcf}",
                Title = "Photo 09",
                Subtitle = "Photo 09",
                Image = "/Assets/DataImages/Item-97cbd8f5-e51b-488d-87f5-2ec1c2113576.png",
                Description = "Photo 09",
            },
		};

        public async Task<IEnumerable<OurAlbumSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<OurAlbumSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
