#region Copyright
// 
// DotNetNukeŽ - http://www.dotnetnuke.com
// Copyright (c) 2002-2013
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion
#region Usings

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using DotNetNuke.Application;
using DotNetNuke.Framework;
using DotNetNuke.Framework.Providers;

#endregion

namespace DotNetNuke.Modules.Dashboard.Components.Host
{
    [XmlRoot("hostInfo")]
    public class HostInfo : IXmlSerializable
    {
        public string CachingProvider
        {
            get
            {
                return ProviderConfiguration.GetProviderConfiguration("caching").DefaultProvider;
            }
        }

        public string DataProvider
        {
            get
            {
                return ProviderConfiguration.GetProviderConfiguration("data").DefaultProvider;
            }
        }

        public string FriendlyUrlProvider
        {
            get
            {
                return ProviderConfiguration.GetProviderConfiguration("friendlyUrl").DefaultProvider;
            }
        }

        public string FriendlyUrlEnabled
        {
            get
            {
                return Entities.Host.Host.UseFriendlyUrls.ToString();
            }
        }

        public string FriendlyUrlType
        {
            get
            {
                var urlProvider = (Provider) ProviderConfiguration.GetProviderConfiguration("friendlyUrl").Providers[FriendlyUrlProvider];
                var urlFormat = urlProvider.Attributes["urlformat"];
                return string.IsNullOrWhiteSpace(urlFormat) ? "SearchFriendly" : urlFormat;
            }
        }

        public string HostGUID
        {
            get
            {
                return Entities.Host.Host.GUID;
            }
        }

        public string HtmlEditorProvider
        {
            get
            {
                return ProviderConfiguration.GetProviderConfiguration("htmlEditor").DefaultProvider;
            }
        }

        public string LoggingProvider
        {
            get
            {
                return ProviderConfiguration.GetProviderConfiguration("logging").DefaultProvider;
            }
        }

        public string Permissions
        {
            get
            {
                return SecurityPolicy.Permissions;
            }
        }

        public string Product
        {
            get
            {
                return DotNetNukeContext.Current.Application.Description;
            }
        }

        public string SchedulerMode
        {
            get
            {
                return Entities.Host.Host.SchedulerMode.ToString();
            }
        }

        public string Version
        {
            get
            {
                return DotNetNukeContext.Current.Application.Version.ToString(3);
            }
        }

        public string WebFarmEnabled
        {
            get
            {
                return Services.Cache.CachingProvider.Instance().IsWebFarm().ToString();
            }
        }

        public string JQueryVersion
        {
            get
            {
                return jQuery.Version;
            }
        }

        public string JQueryUIVersion
        {
            get
            {
                return jQuery.UIVersion;
            }
        }

        #region IXmlSerializable Members

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("hostGUID", HostGUID);
            writer.WriteElementString("version", Version);
            writer.WriteElementString("permissions", Permissions);
            writer.WriteElementString("dataProvider", DataProvider);
            writer.WriteElementString("cachingProvider", CachingProvider);
            writer.WriteElementString("friendlyUrlProvider", FriendlyUrlProvider);
            writer.WriteElementString("friendlyUrlEnabled", FriendlyUrlEnabled);
            writer.WriteElementString("friendlyUrlType", FriendlyUrlType);
            writer.WriteElementString("htmlEditorProvider", HtmlEditorProvider);
            writer.WriteElementString("loggingProvider", LoggingProvider);
            writer.WriteElementString("schedulerMode", SchedulerMode);
            writer.WriteElementString("webFarmEnabled", WebFarmEnabled);

            writer.WriteElementString("JQueryVersion", JQueryVersion);
            writer.WriteElementString("JQueryUIVersion", JQueryUIVersion);
        }

        #endregion
    }
}