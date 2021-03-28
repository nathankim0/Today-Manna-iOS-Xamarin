﻿using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;
using TabbedPage = Xamarin.Forms.TabbedPage;
using TodaysManna.Views;

namespace TodaysManna
{
    public partial class MainTabbedPage : TabbedPage
    {
        private readonly NavigationPage navMannaPage;
        private readonly NavigationPage navMccheynePage;
        private readonly NavigationPage navMccheyneCheckListPage;
        private readonly NavigationPage navCalendarPage;
        private readonly NavigationPage navMyPage;
        MccheyneCheckListPage mccheyneCheckListPage;

        public MainTabbedPage()
        {
            //InitializeComponent();

            On<iOS>().SetUseSafeArea(true);
            On<iOS>().SetPrefersHomeIndicatorAutoHidden(true);

            On<Android>().DisableSmoothScroll();
            On<Android>().DisableSwipePaging();
            On<Android>().SetOffscreenPageLimit(4);
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            navMannaPage = new NavigationPage(new MannaPage())
            {
                Title = "만나",
            };
            navMannaPage.IconImageSource = new FontImageSource
            {
                FontFamily = "materialdesignicons",
                Glyph = FontIcons.BookOpenVariant,
            };
            navMannaPage.IconImageSource.SetAppThemeColor(FontImageSource.ColorProperty, Color.Black, Color.White);

            navMccheynePage = new NavigationPage(new MccheynePage())
            {
                Title = "맥체인",
            };
            navMccheynePage.IconImageSource = new FontImageSource
            {
                FontFamily = "materialdesignicons",
                Glyph = FontIcons.BookOpenPageVariantOutline,
            };
            navMccheynePage.IconImageSource.SetAppThemeColor(FontImageSource.ColorProperty, Color.Black, Color.White);

            mccheyneCheckListPage = new MccheyneCheckListPage();
            navMccheyneCheckListPage = new NavigationPage(mccheyneCheckListPage)
            {
                Title = "체크리스트",
            };
            navMccheyneCheckListPage.IconImageSource = new FontImageSource
            {
                FontFamily = "materialdesignicons",
                Glyph = FontIcons.CheckBoxMultipleOutline,
            };
            navMccheyneCheckListPage.IconImageSource.SetAppThemeColor(FontImageSource.ColorProperty, Color.Black, Color.White);

            //navCalendarPage = new NavigationPage(new MannaCalendarView())
            //{
            //    Title = "캘린더",
            //};
            //navCalendarPage.IconImageSource = new FontImageSource
            //{
            //    FontFamily = "materialdesignicons",
            //    Glyph = FontIcons.CalendarOutline,
            //};
            //navCalendarPage.IconImageSource.SetAppThemeColor(FontImageSource.ColorProperty, Color.Black, Color.White);

            navMyPage = new NavigationPage(new MyPage())
            {
                Title = "메모",
            };
            navMyPage.IconImageSource = new FontImageSource
            {
                FontFamily = "materialdesignicons",
                Glyph = FontIcons.BookmarkOutline,
            };
            navMyPage.IconImageSource.SetAppThemeColor(FontImageSource.ColorProperty, Color.Black, Color.White);

            Children.Add(navMannaPage);
            Children.Add(navMccheynePage);
            Children.Add(navMccheyneCheckListPage);
            //Children.Add(navCalendarPage);
            Children.Add(navMyPage);
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage.Equals(navMannaPage))
            {
                FirebaseEventService.eventTracker.SendEvent("view_navMannaPage");
            }
            else if (CurrentPage.Equals(navMccheynePage))
            {
                FirebaseEventService.eventTracker.SendEvent("view_navMccheynePage");
            }
            else if (CurrentPage.Equals(navMccheyneCheckListPage))
            {
                FirebaseEventService.eventTracker.SendEvent("view_navMccheyneCheckListPage");
                mccheyneCheckListPage.ScrollToToday();
            }
            else if (CurrentPage.Equals(navMyPage))
            {
                FirebaseEventService.eventTracker.SendEvent("view_navMyPage");
            }
        }
    }
}