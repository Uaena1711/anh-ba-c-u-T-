using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MisaCommon.Domain
{

    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }


    /// <summary>
    /// Các kiểu dữ liệu của tài sản
    /// CreatedBy: PNHai (18/01/2022)
    /// </summary>
    public class Asset
    {

        #region constructor
        public Asset()
        {
           
            
        }
        #endregion

        #region Properties


        
        [Required]
       
        public Guid AssetId { get; set; }
        [Required]
        [CheckDuplicate]
        public string AssetCode { get; set; }
        [Required]

        public string AssetName { get; set; }

       
        public DateTime? IncreaseDate { get; set; }
    
        public int? TimeUse { get; set; }
        public string? AssetTypeId { get; set; } 

        public string? DepartmentId { get; set; } 
        public double?  WearRate { get; set; }
  
        public int? OriginalPrice { get; set; }
        public int? WearValue { get; set; }
       
        public bool? IsUsed { get; set; }
       
        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
        public string? ModifiedBy { get; set; }
        
       

        #endregion
    }
}
