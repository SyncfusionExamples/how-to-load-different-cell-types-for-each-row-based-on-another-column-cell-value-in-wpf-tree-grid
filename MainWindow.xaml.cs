using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Cells;
using Syncfusion.UI.Xaml.TreeGrid.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace SfTreeGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class SfTreeGridBehavior : Behavior<SfTreeGrid>
    {
        SfTreeGrid treegrid = null;
        protected override void OnAttached()
        {
            treegrid = this.AssociatedObject as SfTreeGrid;
            treegrid.CellRenderers.Remove("Template");
            treegrid.CellRenderers.Add("Template", new TreeGridCellTemplateRenderer());
            treegrid.Loaded += Treegrid_Loaded;
        }

        private void Treegrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.treegrid.View.NodeCollectionChanged += View_NodeCollectionChanged;
            this.treegrid.View.RecordPropertyChanged += View_RecordPropertyChanged1;
        }        

        private void View_RecordPropertyChanged1(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {           
            var treeGridRowGenerator = this.treegrid.GetTreeGridRowGenerator();

            var treeDataRowBase = treeGridRowGenerator.Items.FirstOrDefault(row => row.RowData == sender);
            if (treeDataRowBase != null)
            {                
                var columns = treeDataRowBase.VisibleColumns as List<TreeDataColumnBase>;
                foreach (var dataColumn in columns.Where(column => column.Renderer != null && column.TreeGridColumn != null))
                {
                    dataColumn.UpdateBinding(sender, false);
                }
            }
        }

        private void View_NodeCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems == null)
                return;
            var rowData = (e.OldItems[0] as TreeNode).Item;
            var treeGridRowGenerator = this.treegrid.GetTreeGridRowGenerator();
            var treeGridDataRowBase = treeGridRowGenerator.Items.FirstOrDefault(row => row.RowData == rowData);
            if (treeGridDataRowBase != null)
            {                
                var columns = treeGridDataRowBase.VisibleColumns as List<TreeDataColumnBase>;
                foreach (var dataColumn in columns.Where(column => column.Renderer != null && column.TreeGridColumn != null))
                {
                    dataColumn.UpdateBinding(rowData, false);
                }
            }
        }       
    }

    public class DataTemplateSelectorExt : DataTemplateSelector
    {
        DataTemplate TextBoxTemplate;
        DataTemplate ComboBoxTemplate;
        DataTemplate CheckBoxTemplate;
        DataTemplate CurrencyTemplate;
        DataTemplate UpdownTemplate;
        DataTemplate TextBlockTemplate;

        public DataTemplateSelectorExt()
        {
            TextBlockTemplate = App.Current.Resources["TextBlockTemplate"] as DataTemplate;
            TextBoxTemplate = App.Current.Resources["TextBoxTemplate"] as DataTemplate;
            ComboBoxTemplate = App.Current.Resources["ComboBoxTemplate"] as DataTemplate;
            CheckBoxTemplate = App.Current.Resources["CheckBoxTemplate"] as DataTemplate;
            CurrencyTemplate = App.Current.Resources["CurrencyTemplate"] as DataTemplate;
            UpdownTemplate = App.Current.Resources["UpdownTemplate"] as DataTemplate;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return TextBlockTemplate;
            
            //Here customize based on your scenario

            EmployeeInfo orderInfo = item as EmployeeInfo;
            if (orderInfo == null)
                return TextBlockTemplate;

            switch (orderInfo.LastName)
            {
                case "TextColumn":
                    return TextBoxTemplate;
                case "ComboBoxColumn":
                    return ComboBoxTemplate;
                case "CheckBoxColumn":
                    return CheckBoxTemplate;
                case "CurrencyColumn":
                    return CurrencyTemplate;
                case "GridUpDownColumn":
                    return UpdownTemplate;
                default:
                    return TextBlockTemplate;
            }
        }
    }
}
