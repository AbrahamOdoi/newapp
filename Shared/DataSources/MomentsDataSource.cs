using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class MomentsDataSource : IDataSource<MomentsSchema>
    {
        private readonly IEnumerable<MomentsSchema> _data = new MomentsSchema[]
		{
            new MomentsSchema
            {
                Id = "{4d9c512c-81df-4290-9523-3d570178a209}",
                Title = "Ryan’s 10th birthday party",
                Subtitle = "[Enter date]",
                Image = "/Assets/DataImages/Item-8d70bc51-c21d-4277-ac31-52885eb297e4.jpg",
                Description = "[Insert the moment description here]",
            },
            new MomentsSchema
            {
                Id = "{30a8884c-944a-425f-95f2-7f674ba551f7}",
                Title = "Spinny’s first time home",
                Subtitle = "[Enter date]",
                Image = "/Assets/DataImages/Item-d3dd18d8-4943-4430-b4d5-8da798fd6f8e.png",
                Description = "[Insert the moment description here]",
            },
            new MomentsSchema
            {
                Id = "{59f7dbe1-e5ea-4916-b27a-9fd1f9b4df40}",
                Title = "Puppy love",
                Subtitle = "[Enter date]",
                Image = "/Assets/DataImages/Item-4c56d560-b178-4c22-8ea7-26fcc1ca3738.png",
                Description = "[Insert the moment description here]",
            },
		};

        public async Task<IEnumerable<MomentsSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<MomentsSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
