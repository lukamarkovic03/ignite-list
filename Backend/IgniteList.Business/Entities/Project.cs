﻿using Microsoft.AspNetCore.Builder;
using Spiderly.Shared.Attributes.EF;
using Spiderly.Shared.Attributes.EF.Translation;
using Spiderly.Shared.Attributes.EF.UI;
using Spiderly.Shared.BaseEntities;
using Spiderly.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgniteList.Business.Entities
{
    [DoNotAuthorize]
    public class Project : BusinessObject<long>
    {
        [BlobName]
        [TranslateSingularEn("Logo")]
        public string LogoBlobName { get; set; }

        [StringLength(75, MinimumLength = 1)]
        [Required]
        [TranslateSingularEn("Project Name")]
        public string ProjectName { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string Link { get; set; }

        [UIControlType(nameof(UIControlTypeCodes.TextArea))]
        [StringLength(500, MinimumLength = 1)]
        public string Description { get; set; }

        [ManyToOneRequired]
        [WithMany(nameof(User.Projects))]
        [UIControlType(nameof(UIControlTypeCodes.Dropdown))]
        [UIDoNotGenerate] 
        public virtual UserExtended User { get; set; }

        public virtual List<UserExtended> UpvotedUsers { get; } = new();

        [UIControlType(nameof(UIControlTypeCodes.MultiSelect))]
        [TranslateSingularEn("Select your categories")]
        public virtual List<Category> Categories { get; } = new();



    }
}
