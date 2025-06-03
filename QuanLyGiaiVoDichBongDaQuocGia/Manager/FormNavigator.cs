namespace QuanLyGiaiVoDichBongDaQuocGia.Manager
{
    public class FormNavigator
    {
        private Panel container;
        private Form currentForm;

        public void SetContainer(Panel container)
        {
            this.container = container;
        }

        public void Navigate(Form newForm)
        {
            if(currentForm is not null)
            {
                currentForm.Hide();
            }            

            currentForm = newForm;

            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;

            container.Controls.Clear();
            container.Controls.Add(newForm);

            newForm.Show();
        }
    }
}
