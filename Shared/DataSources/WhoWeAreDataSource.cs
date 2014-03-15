using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class WhoWeAreDataSource : IDataSource<WhoWeAreSchema>
    {
        private readonly IEnumerable<WhoWeAreSchema> _data = new WhoWeAreSchema[]
		{
            new WhoWeAreSchema
            {
                Id = "{be1b0c46-07b8-4b8f-8ef4-caf7e627ab47}",
                Title = "Ryan",
                Subtitle = "[Enter age]",
                Image = "/Assets/DataImages/Item-35b54109-0ebc-4499-8c16-d5cfe932d446.jpg",
                Description = "[Insert the family member description here]",
            },
            new WhoWeAreSchema
            {
                Id = "{257593a6-5467-4254-a614-4a149254f7be}",
                Title = "Sarah",
                Subtitle = "[Enter age]",
                Image = "/Assets/DataImages/Item-6f3dd35c-634f-4418-bf9b-4cfdae64639d.jpg",
                Description = "[Insert the family member description here]",
            },
            new WhoWeAreSchema
            {
                Id = "{d92a0969-2a38-4e94-b290-e4b164d0cd10}",
                Title = "Julia",
                Subtitle = "[Enter age]",
                Image = "/Assets/DataImages/Item-f15fca6e-45e7-4688-b3f0-343a1e62a008.jpg",
                Description = "[Insert the family member description here]",
            },
            new WhoWeAreSchema
            {
                Id = "{e1e77ea9-b070-42cf-98c8-46be558b1c24}",
                Title = "John",
                Subtitle = "[Enter age]",
                Image = "/Assets/DataImages/Item-33c9807a-388d-4dd0-b11c-88dd3614fbf7.jpg",
                Description = "[Insert the family member description here]",
            },
            new WhoWeAreSchema
            {
                Id = "{d14698cd-dff0-4653-af32-1f23ef6574ef}",
                Title = "Spinny",
                Subtitle = "[Enter age]",
                Image = "/Assets/DataImages/Item-298e1435-a172-4fc6-b5f0-c2a1108f6c7d.png",
                Description = "[Insert the family member description here]",
            },
		};

        public async Task<IEnumerable<WhoWeAreSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<WhoWeAreSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
