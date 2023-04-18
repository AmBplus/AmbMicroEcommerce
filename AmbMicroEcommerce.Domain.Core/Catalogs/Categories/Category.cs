using DevTubeCommerce.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTubeCommerce.Domain.Core.Catalogs.Categories
{
    public class Category : AggregateRoot<CategoryId>
    {
        public string CategoryName { get; private set; }
        public bool IsActive { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyList<Feature> Features => _feature;
        private readonly List<Feature> _feature = new List<Feature>();
        
        internal static Category CreateNew(string categoryName, bool isActive, string desscription, List<FeatureData> featureDatas)
        {
            return new Category(categoryName, isActive, desscription, featureDatas);
        }

        private void BuildFeatures(List<FeatureData> featureData)
        {
            featureData.ForEach(item =>
            {
                var newFeature = Feature.CreateNew(item.Title, item.Description, item.SortOrder);
                _feature.Add(newFeature);
            });
        }

        private Category(string categoryName, bool isActive, string desscription, List<FeatureData> featureDatas)
        {
            //validation....
            CategoryName = categoryName;
            IsActive = isActive;
            Description = desscription;
        }

        private Category()
        {
        }
    }
}
