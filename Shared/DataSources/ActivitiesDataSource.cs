using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ActivitiesDataSource : IDataSource<ActivitiesSchema>
    {
        private readonly IEnumerable<ActivitiesSchema> _data = new ActivitiesSchema[]
		{
            new ActivitiesSchema
            {
                Id = "{5ccf6463-9c0a-4a2d-aa40-e6ed6954eab7}",
                Title = "Birthday camping",
                Subtitle = "[Enter date]",
                Image = "/Assets/DataImages/Item-da4a233c-de00-4751-9e4e-4b328a7eccbc.jpg",
                Description = "[Insert the activity description here]",
            },
            new ActivitiesSchema
            {
                Id = "{99743b29-d730-4035-bf77-e4e0e3b5c202}",
                Title = "Christmas reunion",
                Subtitle = "[Enter date]",
                Image = "/Assets/DataImages/Item-61065a44-b454-4ac1-ad1a-09ba1af68d5e.jpg",
                Description = "[Insert the activity description here]]",
            },
            new ActivitiesSchema
            {
                Id = "{ac28d711-667e-4103-b736-6cb50c5bdfda}",
                Title = "Disneyland trip",
                Subtitle = "[Enter date]",
                Image = "/Assets/DataImages/Item-aa742bc1-41fc-424a-93e9-d662b14494e5.jpg",
                Description = "[Insert the activity description here]",
            },
            new ActivitiesSchema
            {
                Id = "{ae174d52-c1c7-4709-9cd7-d8316d6854b5}",
                Title = "Thanksgiving dinner",
                Subtitle = "[Enter date]",
                Image = "/Assets/DataImages/Item-0b81ffa4-9f64-4d9b-a44c-9700f77803b9.jpg",
                Description = "[Insert the activity description here]",
            },
		};

        public async Task<IEnumerable<ActivitiesSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<ActivitiesSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
