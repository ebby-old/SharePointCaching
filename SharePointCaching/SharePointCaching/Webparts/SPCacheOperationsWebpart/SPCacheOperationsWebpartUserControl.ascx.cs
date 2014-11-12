using System;
using System.Web.UI;
using Microsoft.Office.Server.ObjectCache;
using SharePointCaching.Common;

namespace SharePointCaching.Webparts.SPCacheOperationsWebpart
{
    public partial class SPCacheOperationsWebpartUserControl : UserControl
    {
        private SPCacheOperations _spCacheOperations;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_spCacheOperations == null)
            {
                _spCacheOperations = new SPCacheOperations(Constants.ServiceName, Constants.SPCacheDemoModule, new TimeSpan(0, 1, 0));
            }
        }

        protected void AddItemButton_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ItemNameTextBox.Text) || string.IsNullOrEmpty(ItemValueTextBox.Text))
            {
                AddItemsOutputTextBox.Text += string.Format("{0} : Item Name or Item Value should not be blank\n", DateTime.Now);
            }
            else
            {
                var expiryTime = _spCacheOperations.AddItemsToCache(ItemNameTextBox.Text, ItemValueTextBox.Text);

                AddItemsOutputTextBox.Text +=
                    string.Format("{0} : Added {1} => Expires : {2} \tCount={3}\n",
                        DateTime.Now,
                        ItemNameTextBox.Text,
                        expiryTime,
                        SPCache.Cache.GetItemCount(Constants.SPCacheDemoModule));
            }
        }

        protected void ReadItemButton_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ItemNameToGetTextBox.Text))
            {
                ReadItemsOutputTextBox.Text = string.Format("{0} : Item Name should not be blank\n", DateTime.Now);
            }
            else
            {
                var value = _spCacheOperations.GetItemFromCache(ItemNameToGetTextBox.Text);

                if (value == null)
                {
                    ReadItemsOutputTextBox.Text += string.Format("{0} : {1} cannot be found / is null\n",
                        DateTime.Now,
                        ItemNameToGetTextBox.Text);
                }
                else
                {
                    ReadItemsOutputTextBox.Text += string.Format("{0} : {1} => {2}\n",
                        DateTime.Now,
                        ItemNameToGetTextBox.Text,
                        value);
                }
            }
        }

        protected void DeleteItemButton_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ItemNameToDeleteTextBox.Text))
            {
                ReadItemsOutputTextBox.Text += string.Format("{0} : Item Name should not be blank\n", DateTime.Now);
            }
            else
            {
                _spCacheOperations.DeleteItemFromCache(ItemNameToDeleteTextBox.Text);
                ReadItemsOutputTextBox.Text += string.Format("{0} : Item {1} deleted\n", DateTime.Now,
                    ItemNameToDeleteTextBox.Text);
            }
        }

        protected void CacheExistsButton_OnClick(object sender, EventArgs e)
        {
            OtherOperationsTextBox.Text += string.Format("{0} : Cache Exists? {1}\n", DateTime.Now,
                _spCacheOperations.CacheExists());
        }
    }
}
