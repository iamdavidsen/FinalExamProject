using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunit;
using KDBS.Data;
using KDBS.Models;
using KDBS.Pages.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Xunit;

namespace KDBSTest
{
    public class ComponentsTest
    {
        [Fact]
        public void RenderCardComponents()
        {
            // Arrange: render the Counter.razor component
            using var ctx = new TestContext();

            int counter = 0;
            Action<MouseEventArgs> action = _ => { counter++; };

            var cut = ctx.RenderComponent<CardOverlay>(cardOverlay => cardOverlay
                .AddChildContent<CardHeaderArea>(cardHeaderArea => cardHeaderArea
                .Add(p => p.OnClickCallback, action)
                .Add(p => p.HeaderText, "Testing")
                )
            );

            Assert.Equal("Testing", cut.Find("h1").TextContent);

            cut.Find("button").Click();

            Assert.Equal(1, counter);
        }
    }
}
