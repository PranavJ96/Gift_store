using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ComboBoxWPF
{
    public class ComboBoxViewModel
    {
        public List<string> giftForCategory { get; set; }
        public List<string> ocassionCategory1 { get; set; }
        public ComboBoxViewModel()
        {
            giftForCategory = new List<string>
            {
                "Him",
                "Her",
                "Teen -> boy",
                "Teen -> girl",
                "Kids -> boy",
                "Kids -> girl",
                "Baby -> boy",
                "Baby -> girl"
            };
            ocassionCategory1 = new List<string>
            {
                "Him",
                "Her",
                "Teen -> boy",
                "Teen -> girl",
                "Kids -> boy",
                "Kids -> girl",
                "Baby -> boy",
                "Baby -> girl"
            };
        }
        public ComboBoxViewModel(string obj)
        {
            giftForCategory = new List<string>
            {
                "Him",
                "Her",
                "Teen -> boy",
                "Teen -> girl",
                "Kids -> boy",
                "Kids -> girl",
                "Baby -> boy",
                "Baby -> girl"
            };
            if (obj.Contains("Him"))
            {
                ocassionCategory1 = new List<string>
                {
                    "Him",
                    "Her",
                    "Teen -> boy",
                    "Teen -> girl",
                    "Kids -> boy",
                    "Kids -> girl",
                    "Baby -> boy",
                    "Baby -> girl"
                };
            }
            else if (obj.Contains("Her"))
            {
                ocassionCategory1 = new List<string>
                {
                    "Him",
                    "Her",
                    "Teen -> boy",
                    "Teen -> girl",
                    "Kids -> boy",
                    "Kids -> girl",
                    "Baby -> boy",
                    "Baby -> girl"
                };
            }
            else if (obj.Contains("Teen -> boy"))
            {
                ocassionCategory1 = new List<string>
                {
                    "Him",
                    "Her",
                    "Teen -> boy",
                    "Teen -> girl",
                    "Kids -> boy",
                    "Kids -> girl",
                    "Baby -> boy",
                    "Baby -> girl"
                };
            }
            else if (obj.Contains("Teen -> girl"))
            {
                ocassionCategory1 = new List<string>
                {
                    "Him",
                    "Her",
                    "Teen -> boy",
                    "Teen -> girl",
                    "Kids -> boy",
                    "Kids -> girl",
                    "Baby -> boy",
                    "Baby -> girl"
                };
            }
            else if (obj.Contains("Kids -> boy"))
            {
                ocassionCategory1 = new List<string>
                {
                    "Him",
                    "Her",
                    "Teen -> boy",
                    "Teen -> girl",
                    "Kids -> boy",
                    "Kids -> girl",
                    "Baby -> boy",
                    "Baby -> girl"
                };
            }
            else if (obj.Contains("Kids -> girl"))
            {
                ocassionCategory1 = new List<string>
                {
                    "Him",
                    "Her",
                    "Teen -> boy",
                    "Teen -> girl",
                    "Kids -> boy",
                    "Kids -> girl",
                    "Baby -> boy",
                    "Baby -> girl"
                };
            }
            else if (obj.Contains("Baby -> boy"))
            {
                ocassionCategory1 = new List<string>
                {
                    "Him",
                    "Her",
                    "Teen -> boy",
                    "Teen -> girl",
                    "Kids -> boy",
                    "Kids -> girl",
                    "Baby -> boy",
                    "Baby -> girl"
                };
            }
            else
            {
                ocassionCategory1 = new List<string>
                {
                    "Him",
                    "Her",
                    "Teen -> boy",
                    "Teen -> girl",
                    "Kids -> boy",
                    "Kids -> girl",
                    "Baby -> boy",
                    "Baby -> girl"
                };
            }
        }
    }
}
