using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFCarouselPractice
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<int> PageIndice { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }

        public List<Person> People { get; set; }

        public List<MyItem> ItemList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            //People = new List<Person>();
            //for (int i = 0; i < 50; i++)
            //{
            //    People.Add(new Person
            //    {
            //        FirstName = $"FirstName{i}",
            //        LastName = $"LastName{i}",
            //        Age = i,
            //    });
            //}

            ItemList = new List<MyItem>();
            for (int i = 0; i < 50; i++)
            {
                ItemList.Add(new MyItem
                {
                    //0と1が交互に割り当てられる
                    TemplateId = i % 2
                }); ;
            }

            this.BindingContext = this;
        }
    }

    public class MyDataTemplateSelector : DataTemplateSelector
    {
        //切り替えるテンプレートを保持するプロパティを用意する
        public DataTemplate FirstTemplate { get; set; }
        public DataTemplate SecondTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //ここに条件を書き
            //条件にマッチするプロパティを返す
            return ((MyItem)item).TemplateId==0 ? FirstTemplate : SecondTemplate;

            //itemパラメータにはXaml側から各項目にバインドされたオブジェクト
            //今回はMyItemオブジェクトが入ってくる
            //今回はそれを利用してテンプレートを切り替える
        }
    }

    public class MyItem
    {
        public int TemplateId { get; set; }
    }
}
