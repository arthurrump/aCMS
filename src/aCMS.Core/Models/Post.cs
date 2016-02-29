﻿//     Copyright 2016 Arthur Rump
//  
//     Licensed under the Apache License, Version 2.0 (the "License");
//     you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
//  
//         http://www.apache.org/licenses/LICENSE-2.0
//  
//     Unless required by applicable law or agreed to in writing, software
//     distributed under the License is distributed on an "AS IS" BASIS,
//     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//     See the License for the specific language governing permissions and
//     limitations under the License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Core.Models
{
    public class Post : ContentBase
    {
        public Post()
        {
            AuthorDisplay = true;
            DateTimeDisplay = true;
        }

        /// <summary>
        /// Id of the blog this post belongs to.
        /// </summary>
        [Required]
        public int BlogId { get; set; }
        /// <summary>
        /// The blog this post belongs to.
        /// </summary>
        public Blog Blog { get; set; }
    }
}
