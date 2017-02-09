﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoSharingTests.Doubles;
using System.Web.Routing;
using PhotoSharingApplication;
using System.Web.Mvc;

namespace PhotoSharingTests
{
    [TestClass]
    public class RoutingTests
    {

        [TestMethod]
        public void Test_Default_Route_ControllerOnly()
        {
            //This test checks the default route when only the controller is specified
            //Arrange
            var context = 
                new FakeHttpContextForRouting
                (requestUrl: "~/Bob");


            var routes = new RouteCollection();
            PhotoSharingApplication.RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Bob", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
        }

        [TestMethod]
        public void Test_PhotoRoute_With_PhotoID()
        {
            //This test checks the PhotoRoute route. 
            //Arrange
            var context = new FakeHttpContextForRouting(requestUrl: "~/photo/2");
            var routes = new RouteCollection();
            PhotoSharingApplication.RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("Display", routeData.Values["action"]);
            Assert.AreEqual("2", routeData.Values["id"]);
        }

        [TestMethod]
        public void Test_PhotoTitleRoute_WithTitle()
        {
            //This test checks the PhotoTitleRoute route a title is specified
            //Arrange
            var context = new FakeHttpContextForRouting(requestUrl: "~/Photo/Title/My%20Photo");
            var routes = new RouteCollection();
            PhotoSharingApplication.RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("DisplayByTitle", routeData.Values["action"]);
            Assert.AreEqual("My%20Photo", routeData.Values["title"]);
        }
        [TestMethod]
        public void Test_OwnerPhotoRoute()
        {
            //This test checks the PhotoTitleRoute route a title is specified
            //Arrange
            var context = new FakeHttpContextForRouting
                (requestUrl: "~/Bob/test.jpg");
            var routes = new RouteCollection();
            PhotoSharingApplication.RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("DisplayByOwnerPhoto", routeData.Values["action"]);
            Assert.AreEqual("Bob", routeData.Values["owner"]);
            Assert.AreEqual("test.jpg", routeData.Values["filename"]);
        }
        [TestMethod]
        public void Test_Default_HomePage()
        {
            //This test checks the PhotoTitleRoute route a title is specified
            //Arrange
            var context = new FakeHttpContextForRouting
                (requestUrl: "~/Home/Index");
            var routes = new RouteCollection();
            PhotoSharingApplication.RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
           
        }
    }
}
