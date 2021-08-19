using System.Windows.Forms;
using System.Drawing;
using System;

public class CategoryPicker
{
    public static string Prompt(string title, string text, string[] options)
    {
        // Create the form and set the title

        Form f = new Form();
        f.Text = title;

        // Create and initialize our label, text box and buttons

        Label prompt = new Label();
        prompt.Text = text;

        ComboBox cBox = new ComboBox();
        cBox.DropDownStyle = ComboBoxStyle.DropDownList;

        foreach (string s in options)
            cBox.Items.Add(s);

        cBox.SelectedIndex = 0;

        Button ok = new Button();
        ok.Text = "Ok";
        ok.DialogResult = DialogResult.OK;

        Button cancel = new Button();
        cancel.Text = "Cancel";
        cancel.DialogResult = DialogResult.Cancel;

        // Size and position label, combobox, buttons

        const int WIDTH = 350;
        const int HEIGHT = 100;
        const int MARGIN = 12;

        const int TEXT_HEIGHT = 20;
        const int LABEL_HEIGHT = 15;
        const int BUTTON_HEIGHT = 25;
        const int BUTTON_WIDTH = 75;

        const int Y_TEXT = (int)(.35 * HEIGHT + 0.5);
        const int Y_LABEL = Y_TEXT - TEXT_HEIGHT;

        prompt.SetBounds(
           MARGIN,
           Y_LABEL,
           WIDTH / 2 - MARGIN,
           LABEL_HEIGHT
        );
        cBox.Location = new Point(WIDTH / 2 + MARGIN, Y_LABEL);
        cBox.Size = new Size(135, 0);

        int xCancel = WIDTH / 3 - BUTTON_WIDTH / 2;
        int xOk = (2 * WIDTH / 3) - BUTTON_WIDTH / 2;
        int yButton = HEIGHT - BUTTON_HEIGHT - MARGIN / 2;

        ok.SetBounds(xOk, yButton, BUTTON_WIDTH, BUTTON_HEIGHT);
        cancel.SetBounds(xCancel, yButton, BUTTON_WIDTH, BUTTON_HEIGHT);

        // Set form size, add controls

        f.ClientSize = new Size(WIDTH, HEIGHT);

        foreach (var c in new Control[] { prompt, cBox, ok, cancel })
            f.Controls.Add(c);

        // No resizing, no minimize/maximize buttons

        f.FormBorderStyle = FormBorderStyle.FixedDialog;
        f.StartPosition = FormStartPosition.CenterScreen;
        f.MinimizeBox = false;
        f.MaximizeBox = false;
        f.AcceptButton = ok;
        f.CancelButton = cancel;

        return (
           f.ShowDialog() == DialogResult.Cancel ? null : cBox.SelectedItem.ToString()
        );
    }
}