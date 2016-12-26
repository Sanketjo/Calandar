using Xamarin.Forms;
using System;
using System.Collections.Generic;
using Syncfusion.SfCalendar.XForms;

namespace InlineCustomization
{
	public partial class InlineCustomizationPage : ContentPage
	{
		public InlineCustomizationPage()
		{
			InitializeComponent();
			calendar.ShowInlineEvents = true;
			calendar.OnMonthCellLoaded += Calendar_OnMonthCellLoaded;
			calendar.BindingContext = new ViewModel();
		}

		void Calendar_OnMonthCellLoaded(object sender, MonthCell args)
		{
			for (int i = 0; i < calendar.DataSource.Count; i++)
			{
				if (args.Date.Date.CompareTo(calendar.DataSource[i].StartTime.Date) == 0)
				{
					Label lbl = new Label();
					lbl.Text = calendar.DataSource[i].Subject;
					args.View = lbl;
				}
			}
		}
	}

	public class ViewModel
	{
		public ViewModel()
		{
			Collcetion.Add(new CalendarInlineEvent() { StartTime=new DateTime(2016,11,12),EndTime=new DateTime(2016, 11, 12),Subject="Nivin BirthDay" });
			Collcetion.Add(new CalendarInlineEvent() { StartTime = new DateTime(2016, 11, 18), EndTime = new DateTime(2016, 11, 18),Subject = "Raj BirthDay" });
			Collcetion.Add(new CalendarInlineEvent() { StartTime = new DateTime(2016, 11, 24), EndTime = new DateTime(2016, 11, 24),Subject = "Vikram BirthDay" });
			Collcetion.Add(new CalendarInlineEvent() { StartTime = new DateTime(2016, 12, 15), EndTime = new DateTime(2016, 12, 15), Subject = "Suriya BirthDay"});
		}
		CalendarEventCollection collcetion = new CalendarEventCollection();

		public CalendarEventCollection Collcetion
		{
			get
			{
				return collcetion;
			}

			set
			{
				collcetion = value;
			}
		}
	}
}
