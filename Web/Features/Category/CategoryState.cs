using System.Collections.Generic;
using BlazorState;
using Domain.Models;

namespace Web.Features.Categories
{
    public partial class CategoryState : State<CategoryState>
    {
        public List<Category> Categories { get; private set; }
        public override void Initialize()
        {
            Categories = new List<Category>();
        }
    }
}