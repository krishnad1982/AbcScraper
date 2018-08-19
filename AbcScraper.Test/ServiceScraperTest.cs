using System;
using System.Collections.Generic;
using AbcScraper.Core;
using AbcScraper.Core.Contracts;
using AbcScraper.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace AbcScraper.Test
{
    [TestClass]
    public class ServiceScraperTest
    {
        [TestMethod]
        public void Get_Url_Position_Success_Test()
        {
            var _scraperService = new Mock<IScraperService>();

            string[] keyWords = { "conveyancing software" };
            int pageNumber = 100;
            Provider provider = Provider.Google;
            string lookupUrl = "www.smokeball.com.au";

            var returnResut = new List<ScraperResult>{ new ScraperResult
            {
                Keyword = "conveyancing software",
                Positions = "1,33,24"
                }
            };

            _scraperService.Setup(m => m.GetUrlPosition(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<Provider>(), It.IsAny<string>()))
                          .Returns(returnResut);

            var serviceInvoke = _scraperService.Object.GetUrlPosition(keyWords, pageNumber, provider, lookupUrl);
            _scraperService.Verify(x => x.GetUrlPosition(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<Provider>(), It.IsAny<string>()), Times.Once);
            Assert.IsNotNull(serviceInvoke);
            Assert.AreEqual("conveyancing software", serviceInvoke[0].Keyword);
            Assert.AreEqual("1,33,24", serviceInvoke[0].Positions);
        }
        [TestMethod]
        public void Get_Url_Found_Zero_Position_Test()
        {
            var _scraperService = new Mock<IScraperService>();

            string[] keyWords = { "conveyancing software" };
            int pageNumber = 100;
            Provider provider = Provider.Google;
            string lookupUrl = "www.smokeball.com.au";

            var returnResut = new List<ScraperResult>();

            _scraperService.Setup(m => m.GetUrlPosition(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<Provider>(), It.IsAny<string>()))
                          .Returns(returnResut);

            var serviceInvoke = _scraperService.Object.GetUrlPosition(keyWords, pageNumber, provider, lookupUrl);
            _scraperService.Verify(x => x.GetUrlPosition(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<Provider>(), It.IsAny<string>()), Times.Once);
            Assert.AreEqual(serviceInvoke.Count, 0);
        }
        [TestMethod]
        public void Get_Url_Position_Provider_Not_Found_Test()
        {
            var _scraperService = new Mock<IScraperService>();

            string[] keyWords = { "conveyancing software" };
            int pageNumber = 100;
            string provider = "Bing";
            string lookupUrl = "www.smokeball.com.au";

            var returnResut = new List<ScraperResult>{ new ScraperResult
            {
                Keyword = "conveyancing software",
                Positions = "1,33,24"
                }
            };

            _scraperService.Setup(m => m.GetUrlPosition(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<Provider>(), It.IsAny<string>()))
                          .Returns(returnResut);
            var serviceInvoke = Assert.ThrowsException<ArgumentException>(() => _scraperService.Object.GetUrlPosition(keyWords, pageNumber, (Provider)Enum.Parse(typeof(Provider), provider), lookupUrl));
            Assert.AreEqual(serviceInvoke.Message, "Requested value 'Bing' was not found.");
        }
    }
}
