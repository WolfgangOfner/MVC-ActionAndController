using System;
using System.Web.Mvc;
using ControllersAndActions.Controllers;
using FluentAssertions;
using Xunit;

namespace ControllersAndActions.Test
{
    public class ActionTests
    {
        [Fact]
        public void EmptyViewName()
        {
            var testee = new RedirectController();

            var result = testee.EmptyView();

            result.ViewName.Should().Be("");
        }

         [Fact]
        public void ViewName()
        {
            var testee = new RedirectController();

            var result = testee.ViewName();

            result.ViewName.Should().Be("ViewName");
        }

        [Fact]
        public void ViewWithPath()
        {
            var testee = new RedirectController();

            var result = testee.ViewWithPath();

            result.ViewName.Should().Be("~/Views/Derived/Index.cshtml");
        }

        [Fact]
        public void TestingViewBagData()
        {
            var testee = new ViewsWithDataController();

            var result = testee.PassingDataWithViewBag();

            // cast is necessary for fluentassertions
            ((string) result.ViewBag.Message).Should().Be("Hello");
        }

        [Fact]
        public void RedirectToController()
        {
            var testee = new RedirectController();

            var result = testee.Redirect();

            result.Permanent.Should().BeFalse();
            result.Url.Should().Be("/Redirected/Index");
        }

        [Fact]
        public void PermanentRedirectToController()
        {
            var testee = new RedirectController();

            var result = testee.Permanentedirect();

            result.Permanent.Should().BeTrue();
            result.Url.Should().Be("/Redirected/Index");
        }

        [Fact]
        public void RedirectToRoute()
        {
            var testee = new RedirectController();

            var result = testee.RedirectToRoute();

            result.Permanent.Should().BeFalse();
            ((string) result.RouteValues["controller"]).Should().Be("Redirected");
            ((string) result.RouteValues["action"]).Should().Be("Index");
        }

        [Fact]
        public void Unauthorized()
        {
            var testee = new HttpCodesController();

            var result = testee.Unauthorized();

            result.StatusCode.Should().Be(401);
        }

        [Fact]
        public void ViewModelIsDateTime()
        {
            var testee = new ViewsWithDataController();

            var result = testee.PasswingDataWithViewModel();

            ((ViewResult) result).ViewData.Model.Should().BeOfType<DateTime>();
        }

       
    }
}