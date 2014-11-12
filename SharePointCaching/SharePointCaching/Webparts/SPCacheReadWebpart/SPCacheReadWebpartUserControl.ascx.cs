using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SharePointCaching.Common;

namespace SharePointCaching.Webparts.SPCacheReadWebpart
{
    public partial class SPCacheReadWebpartUserControl : UserControl
    {
        private SPCacheOperations _spCacheOperations;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_spCacheOperations == null)
            {
                _spCacheOperations = new SPCacheOperations(Constants.ServiceName, Constants.SPCacheDemoModule, new TimeSpan(0, 1, 0));
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

    }
}
