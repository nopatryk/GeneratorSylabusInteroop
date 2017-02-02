
using GeneratorSylabus.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace GeneratorSylabus
{

    public partial class Main : Form
    {
        private Connection conn;
        public static SqlConnection sqlConn =  new SqlConnection();
        private SylabusField sf;
        private Word.Application oWordApp;
        private Word.Document oDocument;
        private Word.Table sylabus;
        private List<string> paths = new List<string>();
        private string IDsylabus; // 

        public Main()
        {
            InitializeComponent();

            connectToDb();
            if (Settings.Default.auth)
            {
                passwordBox.Enabled = false;
                loginBox.Enabled = false;
            }
            if(sqlConn.State == ConnectionState.Open) // jeśli połączenie jest otwarte wywołaj funkcje allmodulees
                allmodulees();
        }
        private void allmodulees()
        {
              SqlCommand sqlCommand = new SqlCommand("SELECT kierunek FROM kierunek_studiow;", sqlConn);
              SqlDataReader readerFieldFromSylabus = sqlCommand.ExecuteReader();

                    while (readerFieldFromSylabus.Read())
                     {
                         listOfmodulees.Items.Add( readerFieldFromSylabus["kierunek"].ToString());
                     }
                  readerFieldFromSylabus.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            Cursor = Cursors.AppStarting;
            createWordDoc();
            Cursor = Cursors.Default;

        } // tworzy dokument xdoc wypełnia go danymi z sylabusa
        private void createWordDoc()
        {

            //sf.getField(IDsylabus);
            sf = new SylabusField(IDsylabus);
            // Lokalne zmienne
            string[] sameFiles = { }; // tablica dla plików jeśli będą sie powtarzały 
            string fileName; // scieżka pliku do zapisu dokumentu;

            progressBar1.Visible = true;
            progressBar1.Value = 1;
            progressBar1.Refresh();
            progressBar1.Maximum = 44;

            Object oEndOfDoc = "\\endofdoc";
            Object oMissing = System.Reflection.Missing.Value;

            oWordApp = new Word.Application();
            oDocument = new Word.Document();
            progressBar1.Value = 2;
            progressBar1.Refresh();
            oDocument = oWordApp.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oWordApp.ActiveDocument.PageSetup.LeftMargin = 36;
            oWordApp.ActiveDocument.PageSetup.TopMargin = 36;
            oWordApp.ActiveDocument.PageSetup.RightMargin = 36;
            oWordApp.ActiveDocument.PageSetup.BottomMargin = 36;

            oWordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;             // Aktywowanie stopki
            oWordApp.Selection.TypeParagraph();
            // Dodanie numeru strony do stopki i wyśrodkowanie.
            oWordApp.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oWordApp.ActiveWindow.Selection.Font.Name = "Arial";
            oWordApp.ActiveWindow.Selection.Font.Size = 8;
            oWordApp.ActiveWindow.Selection.TypeText("Strona ");
            Object CurrentPage = Word.WdFieldType.wdFieldPage;
            oWordApp.ActiveWindow.Selection.Fields.Add(oWordApp.Selection.Range, ref CurrentPage, ref oMissing, ref oMissing);
            oWordApp.ActiveWindow.Selection.TypeText(" z ");
            Object TotalPages = Word.WdFieldType.wdFieldNumPages;
            oWordApp.ActiveWindow.Selection.Fields.Add(oWordApp.Selection.Range, ref TotalPages, ref oMissing, ref oMissing);


            oWordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;            // aktywowanie nagłówka
            oWordApp.Selection.TypeParagraph();

            oWordApp.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oWordApp.ActiveWindow.Selection.TypeText("Sylabus dla \"" + sf.module+"\"\n");
            oWordApp.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            //INSERTING TAB CHARACTERS
            oWordApp.ActiveWindow.Selection.TypeText("Data wydruku: ");
            Object CurrentDate = Word.WdFieldType.wdFieldDate;
            oWordApp.ActiveWindow.Selection.Fields.Add(oWordApp.Selection.Range, ref CurrentDate, ref oMissing, ref oMissing);

            oWordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument; // aktywowanie głównego dokumentu
            Word.Paragraph oTitlePage;
            oTitlePage = oDocument.Content.Paragraphs.Add(ref oMissing);
            oTitlePage.Range.InsertParagraphBefore();

            oTitlePage.Range.Text = "SYLABUS ";
            oTitlePage.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oTitlePage.Range.Font.Bold = 1;
            oTitlePage.Range.Font.Size = 18;
            oTitlePage.Format.SpaceAfter = 18;
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.Text = "dla";
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.Text = sf.module;
            oTitlePage.Range.InsertParagraphAfter();

            Word.Paragraph oLogoImage;

            oLogoImage = oDocument.Content.Paragraphs.Add(ref oMissing);
            oLogoImage.Range.InlineShapes.AddPicture(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("GeneratorSylabus.exe", "Resources\\logoWSEI.png"), ref oMissing, ref oMissing, ref oMissing);

            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.Font.Bold = 0;
            oTitlePage.Range.Font.Size = 8;
            oTitlePage.Format.SpaceAfter = 5;
            oTitlePage.Range.Text = "WSEI";
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.Text = "ul. Projektowa 4, Lublin";
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.Text = "tel. ";
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.Text = "www.wsei.lublin.pl";
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.Text = "Copyright © WSEI.";
            oTitlePage.Range.InsertParagraphAfter();
            oTitlePage.Range.Text = "Poniższy dokument, jak również informacje w nim zawarte są całkowitą własnością  WSEI Zawarte tu pomysły, procedury, descriptiony procesów, koncepcje, bez względu na formę przedstawienia stanowią tajemnicę handlową  WSEI Wszystkie elementy wymienione powyżej są prawnie chronione, dlatego też wszelkie prawa, w szczególności prawo do kopiowania i rozpowszechniania jak również prawo do tłumaczenia niniejszej pracy są zastrzeżone.";
            oTitlePage.Range.InsertParagraphAfter();

            object oPageBreak = Word.WdBreakType.wdPageBreak;
            oTitlePage.Range.InsertBreak(ref oPageBreak);

            // fokus na głownym dokumencie
            oWordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;

            progressBar(); // postęp w progressBar

            Word.Paragraph breakLine;
            breakLine = oDocument.Content.Paragraphs.Add(ref oMissing);
            breakLine.Range.InsertParagraphBefore();

            Word.Range wrdRng = oDocument.Bookmarks.get_Item(ref oEndOfDoc).Range;
            sylabus = oDocument.Tables.Add(wrdRng, 11, 3, ref oMissing, ref oMissing);
            sylabus.Range.ParagraphFormat.SpaceAfter = 6;
            sylabus.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            sylabus.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            sylabus.Range.ParagraphFormat.SpaceAfter = 1;
            sylabus.Range.Font.Size = 9;
            sylabus.Range.Font.Name = "Cambria";

            Word.Cell cell = sylabus.Cell(1, 1);
            cell.Merge(sylabus.Cell(1, 3));
            cell.Range.Font.Bold = 1;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cell.Range.Text = "OPIS MODUŁU KSZTAŁCENIA";
            cell.Width = 507;

            cell = sylabus.Cell(2, 1);
            cell.Merge(sylabus.Cell(2, 3));
            cell.Range.Text = "1. Nazwa modułu kształcenia: " + sf.module;
            cell.Width = 507;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            progressBar(); // postęp w progressBar

            cell = sylabus.Cell(3, 1);
            cell.Merge(sylabus.Cell(3, 3));
            cell.Range.Text = "2. Nazwa jednostki prowadzącej: " + sf.department;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cell.Width = 507;
            for (int i = 4; i < 8; i++)
            {
                cell = sylabus.Cell(i, 1);
                cell.Merge(sylabus.Cell(i, 2));
                cell.Width = 356;
                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                if (i == 4)
                {
                    cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    cell.Range.Text = "3. Opis studiów: " + sf.directionStudy;
                }
                else if (i == 5)
                {
                    cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    cell.Range.Text = "5. Profil: " + sf.profil;
                }
                else if (i == 6)
                {
                    cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    cell.Range.Text = "7. Kategoria modułu: " + sf.categoryModule;
                }
                else if (i == 7)
                {
                    cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    cell.Range.Text = "9. Język wykładowy: " + sf.languageOfLecture;
                }
            }

            sylabus.Cell(4, 2).Range.Text = "4. Kod modułu: " +sf.codeModule ;
            sylabus.Cell(4, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            sylabus.Cell(4, 2).Width = 151;
            sylabus.Cell(5, 2).Range.Text = "6. Forma studiów: "+sf.formStudy;
            sylabus.Cell(5, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            sylabus.Cell(5, 2).Width = 151;
            sylabus.Cell(6, 2).Range.Text = "8. Semestr: " +sf.semestr;
            sylabus.Cell(6, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            sylabus.Cell(6, 2).Width = 151;
            sylabus.Cell(7, 2).Range.Text = "10. ISCED/ESAC: " + sf.ISCED_ESAC;
            sylabus.Cell(7, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            sylabus.Cell(7, 2).Width = 151;

            cell = sylabus.Cell(8, 1);
            cell.Merge(sylabus.Cell(8, 3));
            cell.Width = 507;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cell.Range.Text = "11. Imię i nazwisko koordynatora modułu: " + sf.coordinatorModule;

            cell = sylabus.Cell(9, 1);
            cell.Merge(sylabus.Cell(9, 3));
            cell.Width = 507;
            object cellRng = cell.Range;
            Word.Paragraph celOgolnyP = oDocument.Content.Paragraphs.Add(ref cellRng);
            celOgolnyP = oDocument.Content.Paragraphs.Add(ref cellRng);

            celOgolnyP.Range.Text = "12. Cel ogólny modułu: \n"+sf.targetModule;
            celOgolnyP.Range.InsertParagraphAfter();
            object oStartCell = cell.Range.Start;
            object oEndBold = cell.Range.Start + 24;
            object oEndCell = cell.Range.End;
            Word.Range rBold = oDocument.Range(ref oStartCell, ref oEndBold);
            Word.Range toLeft = oDocument.Range(ref oStartCell, ref oEndCell);

            toLeft.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            rBold.Bold = 1;
            rBold.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            progressBar(); // postęp w progressBar

            // to chyba moglbym zrobic jakos lepiej
            cell = sylabus.Cell(10, 1);
            cell.Width = 158;
            cell.Merge(sylabus.Cell(10, 3));
            cellRng = cell.Range;
            Word.Paragraph para2 = oDocument.Content.Paragraphs.Add(ref cellRng);
            para2.Range.Text = sf.preReq;
            para2.Range.Font.Bold = 0;
            para2.Range.InsertParagraphBefore();
            Word.Paragraph para = oDocument.Content.Paragraphs.Add(ref cellRng);
            para.Range.Text = "13. Wymagania formalne i wstępne: ";
            para.Range.Font.Bold = 1;
            para.Range.InsertParagraphAfter();
            //
            cell = sylabus.Cell(11, 1);
            cell.Range.Text = "Symbol efektu  modułu";
            cell.Width = 50;

            progressBar();// postęp w progressBar

            cell = sylabus.Cell(11, 2);
            cell.Range.Text = "14. Efekty kształcenia modułu \nStudent: ";
            cell.Range.Font.Bold = 1;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cell.Width = 387;

            cell = sylabus.Cell(11, 3);
            cell.Range.Text = "Symbol efektu kierunkowego";
            cell.Width = 70;

            sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);

            cell.Merge(sylabus.Cell(sylabus.Rows.Count, 3));
            cell.Range.Text = "Wiedza";
            cell.Range.Font.Bold = 1;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int j = 0; j < sf.w; j++)
            {
                if (j == 0)
                    addRowWith3Columns(sylabus);
                if (j != 0 && j < sf.w+1)
                    sylabus.Rows.Add(ref oMissing);

                    for (int i = 0; i < 3; i++)
                    {
                        cell = sylabus.Cell(sylabus.Rows.Count, i + 1);
                        cell.Range.Text = sf.cKnowledge[j, i];
                    }
            }

            sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Merge(sylabus.Cell(sylabus.Rows.Count, 3));
            cell.Range.Text = "Umiejętności";
            cell.Range.Font.Bold = 1;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            for (int j = 0; j < sf.u; j++)
            {
                if (j == 0)
                {
                    addRowWith3Columns(sylabus);
                }
                else
                {
                    sylabus.Rows.Add(ref oMissing);
                }
                for (int i = 0; i < 3; i++)
                {
                    cell = sylabus.Cell(sylabus.Rows.Count, i + 1);
                    cell.Range.Text = sf.cSkills[j, i];
                }
            }
           
            sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Merge(sylabus.Cell(sylabus.Rows.Count, 3));
            cell.Range.Text = "Kompetencje społeczne(postawa)";
            cell.Range.Font.Bold = 1;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int j = 0; j < sf.k; j++)
            {
                if (j == 0)
                    addRowWith3Columns(sylabus);
                if (j != 0 && sf.cCompetences[j, 1] != null)
                    sylabus.Rows.Add(ref oMissing);
                for (int i = 0; i < 3; i++)
                {
                    cell = sylabus.Cell(sylabus.Rows.Count, i + 1);
                    cell.Range.Text = sf.cCompetences[j, i];
                }
            }

            sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Merge(sylabus.Cell(sylabus.Rows.Count, 3));
            cell.Range.Text = "Treści kształcenia";
            cell.Range.Font.Bold = 1;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            addRowWith3Columns(sylabus);

            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Range.Text = "Kurs";
            cell.Width = 70;
            cell = sylabus.Cell(sylabus.Rows.Count, 2);
            cell.Width = 297;
            cell.Range.Text = "Opis kształcenia";

            cell = sylabus.Cell(sylabus.Rows.Count, 3);
            cell.Range.Text = "Literatura podstawowa i dodatkowa";
            cell.Width = 140;

            progressBar(); // postęp w progressBar
         
            sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            cell.Range.Text = sf.getCourseName(0);

            for (int i = 0; i < sf.getCourseCount(); i++)
            {
                cell = sylabus.Cell(sylabus.Rows.Count, 1);
                cell.Range.Text = sf.getCourseName(i);
                cell.Height = 100;
                sylabus.Cell(sylabus.Rows.Count, 2).Range.Text = sf.getDescContent(i);
                sylabus.Cell(sylabus.Rows.Count, 3).Range.Text = sf.getBasicLiterature(i) + "\n" + sf.getAdditionalLiterature(i);

                sylabus.Rows.Add(ref oMissing);
            }

            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Merge(sylabus.Cell(sylabus.Rows.Count, 3));
            cell.Range.Text = "16. Metody i formy zajęć, wymiar, prowadzący";
            cell.Range.Bold = 1;
            cell.Height = 40;
            sylabus.Rows.Add(ref oMissing);

            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Range.Bold = 0;
            cell.Split(1, 10);
            sylabus.Cell(sylabus.Rows.Count, 1).Range.Text = "Kurs";
            sylabus.Cell(sylabus.Rows.Count, 1).SetWidth(sylabus.Cell(sylabus.Rows.Count, 1).Width + 20,Word.WdRulerStyle.wdAdjustProportional);
            sylabus.Cell(sylabus.Rows.Count, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            sylabus.Cell(sylabus.Rows.Count, 2).Range.Text = "Metody dydaktyczne: (dyskusja grupowa, projekt, analiza przypadku, esej, wizyta studialna, analiza literatury, itd.)";
            sylabus.Cell(sylabus.Rows.Count, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            sylabus.Cell(sylabus.Rows.Count, 2).SetWidth(180, Word.WdRulerStyle.wdAdjustFirstColumn);
            cell = sylabus.Cell(sylabus.Rows.Count, 3);
            cell.SetWidth(206, Word.WdRulerStyle.wdAdjustSameWidth);
            cell.Split(2, 1);

            sylabus.Cell(sylabus.Rows.Count - 1, 3).Range.Text = "Forma zajęć / liczba godzin";
            sylabus.Cell(sylabus.Rows.Count - 1, 3).SetWidth(160.5f, Word.WdRulerStyle.wdAdjustNone);
            sylabus.Cell(sylabus.Rows.Count - 1, 3).HeightRule = Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightExactly;
            sylabus.Cell(sylabus.Rows.Count, 3).Split(1, 3);
            sylabus.Cell(sylabus.Rows.Count, 4).Merge(sylabus.Cell(sylabus.Rows.Count, 5));
            sylabus.Cell(sylabus.Rows.Count, 3).Range.Text = "Wykład";

            sylabus.Cell(sylabus.Rows.Count, 3).Range.FormattedText.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
            sylabus.Cell(sylabus.Rows.Count, 3).SetWidth(20, Word.WdRulerStyle.wdAdjustFirstColumn);

            sylabus.Cell(sylabus.Rows.Count, 4).Range.Text = "Aktywa";
            sylabus.Cell(sylabus.Rows.Count, 4).Merge(sylabus.Cell(sylabus.Rows.Count, 10));
            sylabus.Cell(sylabus.Rows.Count, 4).SetWidth(140.4f, Word.WdRulerStyle.wdAdjustSameWidth);
            // komórka pod podpisem wykladowcy
            sylabus.Cell(sylabus.Rows.Count, 5).SetWidth(96, Word.WdRulerStyle.wdAdjustNone);


            sylabus.Cell(sylabus.Rows.Count, 4).Split(2, 1);
            sylabus.Cell(sylabus.Rows.Count, 4).Split(1, 6);
            progressBar(); // postęp w progressBar
            for (int i = 4; i < 10; i++)
            {

                sylabus.Cell(sylabus.Rows.Count, i).Range.FormattedText.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
                sylabus.Cell(sylabus.Rows.Count, i).SetWidth(22.3f, Word.WdRulerStyle.wdAdjustProportional);

                if (i == 8)
                {

                    sylabus.Cell(sylabus.Rows.Count, i).Range.Font.Size = 8;
                    sylabus.Cell(sylabus.Rows.Count, i).Range.FormattedText.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
                    sylabus.Cell(sylabus.Rows.Count, i).SetWidth(23.3f, Word.WdRulerStyle.wdAdjustProportional);
                }
                else if (i == 9)
                {
                    sylabus.Cell(sylabus.Rows.Count, i).Range.Font.Size = 7;
                    sylabus.Cell(sylabus.Rows.Count, i).Range.FormattedText.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
                    sylabus.Cell(sylabus.Rows.Count, i).SetWidth(27.6f, Word.WdRulerStyle.wdAdjustProportional);
                }
            }

            sylabus.Cell(sylabus.Rows.Count, 4).Range.Text = "Cwiczenia";
            sylabus.Cell(sylabus.Rows.Count, 5).Range.Text = "Labolatoria";
            sylabus.Cell(sylabus.Rows.Count, 6).Range.Text = "Seminaria";
            sylabus.Cell(sylabus.Rows.Count, 7).Range.Text = "E-lerning";
            sylabus.Cell(sylabus.Rows.Count, 8).Range.Text = "Zajęcia z praktykiem";
            sylabus.Cell(sylabus.Rows.Count, 9).Range.Text = "Praca własna studenta-ewaluowana";

            sylabus.Cell(sylabus.Rows.Count - 2, 4).Merge(sylabus.Cell(sylabus.Rows.Count - 2, 10));

            sylabus.Cell(sylabus.Rows.Count - 2, 4).SetWidth(80, Word.WdRulerStyle.wdAdjustSameWidth);
            sylabus.Cell(sylabus.Rows.Count - 2, 4).Range.Text = "Nazwisko i imię osoby prowadzącej";
            sylabus.Cell(sylabus.Rows.Count - 2, 4).HeightRule = Word.WdRowHeightRule.wdRowHeightAtLeast;
            sylabus.Cell(sylabus.Rows.Count - 2, 4).SetWidth(96, Word.WdRulerStyle.wdAdjustNone);

            sylabus.Rows.Add(ref oMissing);

            for (int i = 3; i < 10; i++) // zmien wpisywany tekst na poziomy w komórkach od ocen
            {

                cell = sylabus.Cell(sylabus.Rows.Count, i);
                cell.Range.FormattedText.Orientation = Word.WdTextOrientation.wdTextOrientationHorizontal;
                cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            }

            progressBar(); // postęp w progressBar
            for(int i = 0; i < sf.getCourseCount(); i++)
            {
                cell = sylabus.Cell(sylabus.Rows.Count, 1);
                cell.Range.Text = sf.getCourseName(i);

                    sylabus.Cell(sylabus.Rows.Count, 2).Range.Text = sf.getTeachingMethors(i);
                for (int j = 3; j < 10; j++)
                {
                    sylabus.Cell(sylabus.Rows.Count, j).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
                    sylabus.Cell(sylabus.Rows.Count, j).Range.Text = "";
                }

                if (sf.getNameOfForm(i).Equals("Wykład"))
                {
                    sylabus.Cell(sylabus.Rows.Count, 3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray15;
                    sylabus.Cell(sylabus.Rows.Count, 3).Range.Text = sf.getCountOfHours(i);
                }
                if (sf.getNameOfForm(i).Equals("Ćwiczenia"))
                {
                    sylabus.Cell(sylabus.Rows.Count, 4).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray15;
                    sylabus.Cell(sylabus.Rows.Count, 4).Range.Text = sf.getCountOfHours(i);
                }
                 if (sf.getNameOfForm(i).Equals("Labolatoria"))
                {
                    sylabus.Cell(sylabus.Rows.Count, 5).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray15;
                    sylabus.Cell(sylabus.Rows.Count, 5).Range.Text = sf.getCountOfHours(i);
                }
                if (sf.getNameOfForm(i).Equals("Seminaria"))
                {
                    sylabus.Cell(sylabus.Rows.Count, 6).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray15;
                    sylabus.Cell(sylabus.Rows.Count, 6).Range.Text = sf.getCountOfHours(i);
                }
                if (sf.getNameOfForm(i).Equals("e-learning"))
                {
                    sylabus.Cell(sylabus.Rows.Count, 7).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray15;
                    sylabus.Cell(sylabus.Rows.Count, 7).Range.Text = sf.getCountOfHours(i);
                }
                if (sf.getNameOfForm(i).Equals("Zajęcia z praktykiem"))
                {
                    sylabus.Cell(sylabus.Rows.Count, 8).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray15;
                    sylabus.Cell(sylabus.Rows.Count, 8).Range.Text = sf.getCountOfHours(i);
                }
               if (sf.getNameOfForm(i).Equals("Praca własna ewaluowana"))
                {
                    sylabus.Cell(sylabus.Rows.Count, 9).Range.Font.Size = 8;
                    sylabus.Cell(sylabus.Rows.Count, 9).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray15;
                    sylabus.Cell(sylabus.Rows.Count, 9).Range.Text = sf.getCountOfHours(i);
                }

                sylabus.Cell(sylabus.Rows.Count, 10).Range.Text = sf.getInstructorName(i) + " " + sf.getInstructorSurName(i);
                sylabus.Rows.Add(ref oMissing);
            }

            //sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Merge(sylabus.Cell(sylabus.Rows.Count, 10));
            cell.Range.Text = "17.Sposób weryfikacji efektów kształcenia: ";
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cell.SetHeight(20, Word.WdRowHeightRule.wdRowHeightAtLeast);
            cell.Range.Bold = 1;

            sylabus.Rows.Add(ref oMissing);
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Range.Bold = 0;
            cell.Split(1, 4);
            cell.Range.Text = "Kurs";
            cell.SetWidth(70, Word.WdRulerStyle.wdAdjustNone);

            cell = sylabus.Cell(sylabus.Rows.Count, 2);
            cell.SetWidth(176, Word.WdRulerStyle.wdAdjustNone);
            cell.Range.Text = "Sposób oceny";

            cell = sylabus.Cell(sylabus.Rows.Count, 3);
            cell.SetWidth(126, Word.WdRulerStyle.wdAdjustNone);
            cell.Range.Text = "Oceniane efekty modułu";

            cell = sylabus.Cell(sylabus.Rows.Count, 4);
            cell.SetWidth(135, Word.WdRulerStyle.wdAdjustNone);
            cell.Range.Text = "Skalowanie ocen";

            sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
           
            for(int i = 0; i < sf.getCourseCount(); i++)
            {
                sylabus.Cell(sylabus.Rows.Count, 1).Range.Text = sf.getCourseName(i); ;
                sylabus.Cell(sylabus.Rows.Count, 2).Range.Text = sf.getWayOfEvaluting(i); ;
                sylabus.Cell(sylabus.Rows.Count, 3).Range.Text = sf.getEvEffectModule(i);
                sylabus.Cell(sylabus.Rows.Count, 4).Range.Text = sf.getScaleRatings(i);
                sylabus.Rows.Add(ref oMissing);
            }

            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Merge(sylabus.Cell(sylabus.Rows.Count, 4));
            cell.Range.Text = "18. Sposób powstawania oceny podsumowującej moduł:\n" + sf.wayFormationEv;
            cell.Range.Bold = 0;

            sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Range.Text = "19. Bilans godzin i punktów ECTS";
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Split(1, 2);
            cell.Range.Text = "Kategorie zajęć";
            cell.SetWidth(357, Word.WdRulerStyle.wdAdjustNone);

            cell = sylabus.Cell(sylabus.Rows.Count, 2);
            cell.Range.Text = "Obciążenie studenta";
            cell.SetWidth(150, Word.WdRulerStyle.wdAdjustNone);
            cell.Split(2, 1);

            cell = sylabus.Cell(sylabus.Rows.Count + 1, 2);
            cell.Range.Text = "Godziny";
            cell.Split(1, 2);

            cell = sylabus.Cell(sylabus.Rows.Count + 1, 3);
            cell.Range.Text = "Punkty ETCS";

            progressBar(); // postęp w progressBar

            sylabus.Rows.Add(ref oMissing);
            cell = sylabus.Cell(sylabus.Rows.Count, 1);
            cell.Range.Bold = 0;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            for(int i = 0; i < sf.getBalancesCount(); i++)
            {
                cell.Range.Text = sf.getECTSName(i);
                sylabus.Cell(sylabus.Rows.Count, 2).Range.Text = sf.getECTSHours(i);
                sylabus.Cell(sylabus.Rows.Count, 3).Range.Text = sf.getECTS(i);
                if (i<sf.getBalancesCount() - 1)
                {
                    sylabus.Rows.Add(ref oMissing);
                    cell = sylabus.Cell(sylabus.Rows.Count, 1);
                }
            }

            Word.Paragraph podpis = oDocument.Content.Paragraphs.Add(ref oMissing);
            podpis.Range.Font.Size = 7;
            podpis.Range.Text = "\n\n\n\n\n\n.............................................. \t\t\t\t     \t\t\t\t\t          ..............................................";
            podpis.Range.InsertParagraphAfter();
            podpis.Range.Font.Size = 7;
            podpis.Range.Font.Italic = 1;
            podpis.Range.Text = "Czytelny podpis Opiekuna  modułu  \t\t\t\t     \t\t\t\t\t          Podpis Dziekana Wydziału";
            podpis.Range.InsertParagraphAfter();

            // nie wiem co z tym zrobic usuwa pliki tymczasowe (czasami pojawialy sie w folderze z plikami sylabusow) //
            clearFolder();

            try
            {
                sameFiles = Directory.GetFiles(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("GeneratorSylabus.exe", "Sylabusy\\"), sf.module + "*");
            }
            catch (Exception errorIfExist)
            {
                Console.WriteLine("Nie znaleziono żadnych takich samych plików sylabusa\n" + errorIfExist.Message);
            }
            if (sameFiles.Length != 0)
            {
                fileName = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("GeneratorSylabus.exe", "Sylabusy\\") + sf.module + "(Copy) " + (sameFiles.Length + 1);
            }else{
                fileName = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("GeneratorSylabus.exe", "Sylabusy\\") + sf.module;
            }
            oWordApp.Visible = true;
            progressBar1.Visible = false;
            button1.Visible = true;

            try
            {
                Console.WriteLine(fileName);
                this.oWordApp.ActiveDocument.SaveAs(fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            }catch (Exception wordException){
                MessageBox.Show("Plik nie został zapisany!\n\n" + wordException.Message, "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void connectToDb()
        {
            conn = new Connection();
            sqlConn = conn.connectToDb();
            if (sqlConn.State == ConnectionState.Open)
            {
                succesPanel.Visible = true;
                unsucesfullPanel.Visible = false;
            }else{
                succesPanel.Visible = false;
                unsucesfullPanel.Visible = true;
            }
        } // polacza do bazy danych i zmienia connection panel w zależności czy polaczenie sie udało czy nie
        private void addRowWith3Columns(Word.Table table)
        {
            object oMissing = System.Reflection.Missing.Value;

            table.Rows.Add(ref oMissing);

            Word.Cell cell = table.Cell(table.Rows.Count, 1);
            cell.Split(1, 3);
            cell = table.Cell(cell.RowIndex, 1);
            cell.Range.Text = " ";
            cell.Width = 50;

            cell = table.Cell(cell.RowIndex, 2);
            cell.Range.Text = " ";
            cell.Range.Font.Bold = 0;
            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cell.Width = 387;

            cell = table.Cell(cell.RowIndex, 3);
            cell.Range.Text = " ";
            cell.Width = 70;         
        } // zmiania wiersz z jedną kolumne na wiersz z trzema kolumnami z dopasowanymi szerokościami.
        private void progressBar()
        {
                progressBar1.Value = progressBar1.Value + 5;
                progressBar1.Refresh();  
        } // przesuwa progres w pasku progresu
        private void findFileInDirectory()
        {
            string[] filePaths = Directory.GetFiles(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("GeneratorSylabus.exe", "Sylabusy\\"), "*.docx");

            filesList.Items.Clear();

            for (int i = 0; i < filePaths.Length; i++)
            {
                if (filePaths[i].Equals("") || filePaths[i].IndexOf("~") != -1) // pomijam pozycje które nie mają nazwy
                {
                    break;
                }
                string[] names = filePaths;

                //listOfSylabus.Items.Add(names[i].Substring(names[i].LastIndexOf('\\') + 1), 0);
                System.IO.FileInfo file = new System.IO.FileInfo(names[i]);
                string dateFile = file.LastWriteTime.ToString();
                filesList.Items.Add(names[i].Substring(names[i].LastIndexOf('\\') + 1), 0);
                filesList.Items[i].SubItems.Add(dateFile);
                filesList.Items[i].Tag = filePaths[i];
            }
        } // szuka plików (sylabusów) w folderze Sylabus 
        private void clearFolder()
        {
            string[] fileToDelete = Directory.GetFiles(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("GeneratorSylabus.exe", "Sylabusy\\"), "*.TMP");
            for (int i = 0; i < fileToDelete.Length; i++)
            {
                    File.Delete(fileToDelete[i]);
             
            }
        }// usuwa pliki tymczasowe z folderu
        private void searchSylabus_TextChanged(object sender, EventArgs e)
        {
            string[] filePaths = Directory.GetFiles(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("GeneratorSylabus.exe", "Sylabusy\\"), "*" + searchSylabus.Text + "*.docx");
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (filePaths[i].IndexOf("~") > 0) // jeśli znajdzie pozycje która ma ~~ w nazwie ustawia ją na "" by później pominąć ją w listowaniu. #888
                {
                    filePaths[i] = "";
                }
            }
            filesList.Items.Clear();

            for (int i = 0; i < filePaths.Length; i++)
            {
                if (filePaths[i].Equals("")) // pomijam pozycje które nie mają nazwy
                {
                    break;
                }

                string[] names = filePaths;
                filesList.Items.Add(names[i].Substring(names[i].LastIndexOf('\\') + 1), 0);

                System.IO.FileInfo file = new System.IO.FileInfo(names[i]);
                string dateFile = file.LastWriteTime.ToString();
                filesList.Items[i].SubItems.Add(dateFile);

                filesList.Items[i].Tag = filePaths[i];
            }
        } // wpisanie tekstu powoduje uruchomienie wyszukiwarki sylabusow w liscie
        private void mainBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = true;
            settingsPanel.Visible = false;
            sylabusPanel.Visible = false;
        } // pokazuje główny panel
        private void settingsBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            sylabusPanel.Visible = false;
            settingsPanel.Visible = true;
        } // pokazuje panel z ustawieniamie
        private void saveSettings_Click(object sender, EventArgs e)
        {
            Boolean isOpen = false;
            DialogResult youSure = DialogResult.No;
            if (sqlConn.State == ConnectionState.Open)
            {
                isOpen = true;
                youSure = MessageBox.Show("Jesteś już połączony.\nJesteś pewien, że chcesz to zrobić? \n", "Sukces", MessageBoxButtons.YesNo);
            }
            if(youSure == DialogResult.Yes || !isOpen)
            {
                    
                Settings.Default.Upgrade();
                Settings.Default.ip = ipBox.Text;
                Settings.Default.dbName = databaseName.Text;
                Settings.Default.auth = checkBox1.Checked;
                Settings.Default.login = loginBox.Text;
                Settings.Default.password = passwordBox.Text;
                Settings.Default.port = portTextBox.Text;
                Settings.Default.Save();

                connectToDb();
                if(sqlConn.State == ConnectionState.Open)
                {
                    DialogResult result = MessageBox.Show("Połączenie z bazą danych zostało nawiązane \n"
                         +"Aby aplikacja działała poprawnie wymagany jest restart, czy chcesz to zrobić teraz?", "Sukces", MessageBoxButtons.YesNo);
                 if (result == DialogResult.Yes)
                    {
                        Main m = new Main();
                        m.Show();
                        this.Hide(); //to turn off current app
                    }
               }
            }
        } // zapisuje ustawienia do połączenia
        private void sylabusBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            settingsPanel.Visible = false;
            sylabusPanel.Visible = true;
            findFileInDirectory();
        } // pokazuje panel z sylabusami w folderze Sylabus
        private void filesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (filesList.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = filesList.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                string path = filesList.Items[intselectedindex].Tag.ToString();

                Word.Application ap = new Word.Application();
                Word.Document wDoc = ap.Documents.Open(path, ReadOnly: true, Visible: true);
                wDoc.Activate();
                ap.Visible = true;
            }

        }// lista dostepnych sylabusów juz zapisanych w folderze
        private void connectionIcon_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conn.errorStr,"",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }  // jeśli nie ma połączenia dzięki tej metodzie po kliknieciu w ikone (czerwona kropka) wyrzuca wiadomosc jaki to jest błąd
        private void deleteFile_Click_1(object sender, EventArgs e)
        {
            string deletedFiles = "Usunięte pliki: \n";
            foreach (int i in filesList.SelectedIndices)
            {
                paths.Add(filesList.Items[i].Tag.ToString());
                deletedFiles += filesList.Items[i].Tag.ToString() + "\n";
            }
            for (int i = 0; i < paths.Count; i++)
            {
                File.Delete(paths[i]);
            }

            MessageBox.Show(deletedFiles);
            paths.Clear();
            findFileInDirectory();
        } // usuwa zaznaczony plik w listofSylabus
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                loginBox.Enabled = false;
                passwordBox.Enabled = false;
            }else
            {
                loginBox.Enabled = true;
                passwordBox.Enabled = true;
            }
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public Point downPoint = Point.Empty;
        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint == Point.Empty)
            {
                return;
            }
            Point location = new Point(
                this.Left + e.X - downPoint.X,
                this.Top + e.Y - downPoint.Y);
            this.Location = location;
        }
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = new Point(e.X, e.Y);
        }
        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = Point.Empty;
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Aqua;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }
        private void listOfmodulees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOfmodulees.SelectedItem != null)
            {
                string directionStudy = listOfmodulees.SelectedItem.ToString();
                SqlCommand sqlCommand = new SqlCommand("SELECT [IDsylabus],[Nazwa],[Forma_studiow],[Semestr] FROM Sylabus INNER JOIN Nazwa_modulu ON Sylabus.IDnazwa_modulu = Nazwa_modulu.IDnazwa_modulu INNER JOIN Kierunek_studiow ON Sylabus.IDKierunek_studiow = kierunek_studiow.IDKierunek_studiow INNER JOIN Forma_studiow ON Sylabus.IDforma_studiow = Forma_studiow.IDforma_studiow where Sylabus.IDKierunek_studiow =  (SELECT IDKierunek_studiow FROM Kierunek_studiow WHERE Kierunek LIKE @k)", sqlConn);
                sqlCommand.Parameters.AddWithValue("@k", listOfmodulees.SelectedItem.ToString());
                if (sqlConn.State == ConnectionState.Open)
                {
                    SqlDataReader readerFieldFromSylabus = sqlCommand.ExecuteReader();

                    listViewSylabus.Items.Clear();

                     while (readerFieldFromSylabus.Read())
                     {
                        string semestr;
                        string semestrString = readerFieldFromSylabus["Semestr"].ToString().ToLower();
                        switch (readerFieldFromSylabus["Semestr"].ToString())
                        {
                            case "pierwszy":
                                semestr = "1";
                                break;
                            case "drugi":
                                semestr = "2";
                                break;
                            case "trzeci":
                                semestr = "3";
                                break;
                            case "czwarty":
                                semestr = "4";
                                break;
                            case "piąty":
                                semestr = "5";
                                break;
                            case "szósty":
                                semestr = "6";
                                break;
                            case "siódmy":
                                semestr = "7";
                                break;
                            case "ósmy":
                                semestr = "8";
                                break;

                            default:
                                semestr = "0";
                                break;
                        }

                        MyListItem li = new MyListItem
                        {
                            Text = readerFieldFromSylabus["Nazwa"].ToString(),
                            idSylabus = readerFieldFromSylabus["IDsylabus"].ToString()
                        };
                        li.SubItems.Add(semestr);
                        li.SubItems.Add(readerFieldFromSylabus["Forma_studiow"].ToString());
                        listViewSylabus.Items.Add(li);


                    }
                         readerFieldFromSylabus.Close();

                     }else{

                    MessageBox.Show("Połączenie zostało zerwane...\nZresetuj aplikacje.\n\nKliknij w ikone połączenia (prawy górny róg), aby dowiedzieć się więcej.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void listViewSylabus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSylabus.SelectedItems.Count > 0)
            {
                //ComboItem item = (ComboItem)listboxOfSylabus.SelectedItem;
                MyListItem item = (MyListItem)listViewSylabus.SelectedItems[0];

                IDsylabus = item.idSylabus;
                currmoduleeText.Text = "Do wygenerowania: " + item.Text;
                button1.Visible = true;
            }
        }
        private void ipBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Niedozwolony znak.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }


        public class ComboItem : object
        {
            protected String m_Name;
            protected String m_Module;
            protected string m_Value;

            public ComboItem( String module, string in_value)
            {
                m_Module = module;
                m_Value = in_value;
            }

            public override string ToString()
            {
                return m_Module;
            }
            public string getValue()
            {
                return m_Value;
            }
        }
        public class MyListItem : ListViewItem
        {
            public String idSylabus { get; set; }
        }

    }

    class Sylabus
    {
        string sylabusId;
        public SqlConnection sqlConn;
        Connection conn;

        public Sylabus(string sylabusId)
        {
            this.sylabusId = sylabusId;
            sqlConn = new SqlConnection();
            conn = new Connection();
            sqlConn = conn.connectToDb();

        }
    }
    class SylabusField : Sylabus
    {
        //SqlConnection sqlConn;
        SqlDataReader readerFieldFromSylabus;
        //
        // Liczniki wierszy dla tablic kursow (wiedza, umiejetnosc, kompetencje)
        //
        public int w = 0, u = 0, k = 0;

        public string[,] cKnowledge = new string[10, 3];
        public string[,] cSkills = new string[10, 3];
        public string[,] cCompetences = new string[10, 3];
        //
        // Lista w której mieścić będą sie pola z tresci kształcenia kurs A; kurs B: itp... każdy kolejny obiekt listy to kolejny kurs
        //
        private List<contentOfEducation> course;
        private List<bilansECTS> balances;

        public string module { get; private set; }
        public string department { get; private set; }
        public string directionStudy { get; private set; }
        public string codeModule { get; private set; }
        public string profil { get; private set; }
        public string formStudy { get; private set; }
        public string categoryModule { get; private set; }
        public string semestr { get; private set; }
        public string languageOfLecture { get; private set; }
        public string ISCED_ESAC { get; private set; }
        public string coordinatorModule { get; private set; }
        public string targetModule { get; private set; }
        public string formalReq { get; private set; }
        public string preReq { get; private set; }
        public string symbol { get; private set; }
        public string description { get; private set; }
        public string IdType { get; private set; }
        public string symbolEffectModule { get; private set; }
        public string wayFormationEv { get; private set; }

        public SylabusField(string sylabusId) : base(sylabusId)
        {
            course = new List<contentOfEducation>();
            balances = new List<bilansECTS>();
            SqlCommand sqlCommand = new SqlCommand("SELECT [IDsylabus], [Nazwa], [Nazwa_wydzialu], [Kierunek], [Kod], [Profil], [Forma_studiow], [Kategoria], [Jezyk], [Imie], [Nazwisko], [Stopien], [sposob_powstania_oceny], * FROM Sylabus INNER JOIN Nazwa_modulu ON Sylabus.IDnazwa_modulu = Nazwa_modulu.IDnazwa_modulu INNER JOIN Wydzial ON Sylabus.IDnazwa_jednostki_prowadzacej = wydzial.IDWydzial INNER JOIN Kierunek_studiow ON Sylabus.IDKierunek_studiow = Kierunek_studiow.IDKierunek_studiow INNER JOIN Kod_modulu ON Sylabus.IDkod_modulu = Kod_modulu.IDkod_modulu INNER JOIN Profil ON Sylabus.IDprofil = Profil.IDprofil INNER JOIN Forma_studiow ON Sylabus.IDforma_studiow = Forma_studiow.IDforma_studiow INNER JOIN Kategoria_modulu ON Sylabus.IDkategoria_modulu = Kategoria_modulu.IDkategoria_modulu INNER JOIN Jezyk_wykladowy ON Sylabus.IDjezyk_wykladowy = Jezyk_wykladowy.IDjezyk_wykladowy INNER JOIN Wykladowca ON Sylabus.IDwykladowca = Wykladowca.IDwykladowca WHERE IDsylabus= @sylabusId", sqlConn);
            sqlCommand.Parameters.Add("@sylabusId", SqlDbType.Int);
            sqlCommand.Parameters["@sylabusId"].Value = sylabusId;
            readerFieldFromSylabus = sqlCommand.ExecuteReader();

            while (readerFieldFromSylabus.Read())
            {

                module = readerFieldFromSylabus["Nazwa"].ToString();
                department = readerFieldFromSylabus["Nazwa_wydzialu"].ToString();
                directionStudy = readerFieldFromSylabus["Kierunek"].ToString();
                codeModule = readerFieldFromSylabus["Kod"].ToString();
                profil = readerFieldFromSylabus["Profil"].ToString();
                formStudy = readerFieldFromSylabus["Forma_studiow"].ToString();
                categoryModule = readerFieldFromSylabus["Kategoria"].ToString();
                semestr = readerFieldFromSylabus["semestr"].ToString();
                languageOfLecture = readerFieldFromSylabus["Jezyk"].ToString();
                coordinatorModule = readerFieldFromSylabus["Stopien"].ToString() + " " + readerFieldFromSylabus["Imie"].ToString() + " " + readerFieldFromSylabus["Nazwisko"].ToString();
                ISCED_ESAC = readerFieldFromSylabus["ISCED/ESAC"].ToString();
                targetModule = readerFieldFromSylabus["Cel_ogolny_modulu"].ToString();
                preReq = readerFieldFromSylabus["Wymagania_formalne_wstepne"].ToString();
                wayFormationEv = readerFieldFromSylabus["sposob_powstania_oceny"].ToString();

            }

            readerFieldFromSylabus.Close();

            sqlCommand = new SqlCommand("Select [Symbol], [opis],[IdTyp], [Symbol_efektu_modulu] from[wsei2].dbo.[Efekt_ksztalcenia_modulu] where idsylabus = @sylabusId", sqlConn);
            sqlCommand.Parameters.Add("@sylabusId", SqlDbType.Int);
            sqlCommand.Parameters["@sylabusId"].Value = sylabusId;

            readerFieldFromSylabus = sqlCommand.ExecuteReader();

            w = 0; // licznik ile rekordów ma typ wiedza
            u = 0; // licznik ile rekordów ma typ umiejetnosci
            k = 0; // licznik ile rekordów ma typ kompetencje
            while (readerFieldFromSylabus.Read())
            {
                if (readerFieldFromSylabus["IdTyp"].ToString() == "1")
                {
                    cKnowledge[w, 0] = readerFieldFromSylabus["Symbol"].ToString();
                    cKnowledge[w, 1] = readerFieldFromSylabus["opis"].ToString();
                    cKnowledge[w, 2] = readerFieldFromSylabus["Symbol_efektu_modulu"].ToString();
                    w++;
                }
                else if (readerFieldFromSylabus["IdTyp"].ToString() == "2")
                {
                    cSkills[u, 0] = readerFieldFromSylabus["Symbol"].ToString();
                    cSkills[u, 1] = readerFieldFromSylabus["opis"].ToString();
                    cSkills[u, 2] = readerFieldFromSylabus["Symbol_efektu_modulu"].ToString();
                    u++;
                }
                else if (readerFieldFromSylabus["IdTyp"].ToString() == "3")
                {
                    cCompetences[k, 0] = readerFieldFromSylabus["Symbol"].ToString();
                    cCompetences[k, 1] = readerFieldFromSylabus["opis"].ToString();
                    cCompetences[k, 2] = readerFieldFromSylabus["Symbol_efektu_modulu"].ToString();
                    k++;
                }

            }
            readerFieldFromSylabus.Close();

            sqlCommand = new SqlCommand("SELECT Kurs.IDSylabus, "
                                          + "Kurs.Nr_nazwa_kursu, Kurs.opis_tresci_ksztalcenia, "
                                          + "Kurs.Literatura_podstawowa, Kurs.Literatura_dodatkowa, "
                                          + "Kurs.Metody_dydaktyczne, Forma_zajec.Nazwa_formy, "
                                          + "Kurs.Liczba_godzin, Wykladowca.Imie, Wykladowca.Nazwisko, "
                                          + "Kurs.Sposob_oceny, Kurs.Oceniane_efekty_modulu, "
                                          + "Kurs.Skalowanie_ocen FROM Kurs "
                                          + "INNER JOIN Forma_zajec ON Kurs.IDforma_zajec = Forma_zajec.IDforma_zajec "
                                          + "INNER JOIN Wykladowca ON Kurs.IDwykladowca = Wykladowca.IDwykladowca where Kurs.IDSylabus = @sylabusId", sqlConn);
            sqlCommand.Parameters.Add("@sylabusId", SqlDbType.Int);
            sqlCommand.Parameters["@sylabusId"].Value = sylabusId;

            readerFieldFromSylabus = sqlCommand.ExecuteReader();

            while (readerFieldFromSylabus.Read())
            {
                course.Add(new contentOfEducation(readerFieldFromSylabus["Nr_nazwa_kursu"].ToString(),
                                                readerFieldFromSylabus["opis_tresci_ksztalcenia"].ToString(),
                                                readerFieldFromSylabus["Literatura_podstawowa"].ToString(),
                                                readerFieldFromSylabus["Literatura_dodatkowa"].ToString(),
                                                readerFieldFromSylabus["Metody_dydaktyczne"].ToString(),
                                                readerFieldFromSylabus["Nazwa_formy"].ToString(),
                                                readerFieldFromSylabus["Liczba_godzin"].ToString(),
                                                readerFieldFromSylabus["Imie"].ToString(),
                                                readerFieldFromSylabus["Nazwisko"].ToString(),
                                                readerFieldFromSylabus["Sposob_oceny"].ToString(),
                                                readerFieldFromSylabus["Oceniane_efekty_modulu"].ToString(),
                                                readerFieldFromSylabus["Skalowanie_ocen"].ToString()
                                                ));
            }
            readerFieldFromSylabus.Close();

            sqlCommand = new SqlCommand("SELECT Nazwa,Godziny,ECTS FROM wsei2.dbo.Kategoria_zajec AS K INNER JOIN wsei2.dbo.Bilans_ECTS E ON E.IDkategoria_zajec = K.IDkategoria_zajec where IDSylabus = @sylabusId", sqlConn);
            sqlCommand.Parameters.Add("@sylabusId", SqlDbType.Int);
            sqlCommand.Parameters["@sylabusId"].Value = sylabusId;

            readerFieldFromSylabus = sqlCommand.ExecuteReader();

            while (readerFieldFromSylabus.Read())
            {
                if (readerFieldFromSylabus["Godziny"] == null && readerFieldFromSylabus["ECTS"] != null)
                {
                    balances.Add(new bilansECTS(readerFieldFromSylabus["Nazwa"].ToString(), "", readerFieldFromSylabus["ECTS"].ToString()));
                }
                if (readerFieldFromSylabus["Godziny"] != null && readerFieldFromSylabus["ECTS"] == null)
                {
                    balances.Add(new bilansECTS(readerFieldFromSylabus["Nazwa"].ToString(), readerFieldFromSylabus["Godziny"].ToString(), ""));
                }
                if (readerFieldFromSylabus["Godziny"] == null && readerFieldFromSylabus["ECTS"] == null)
                {
                    balances.Add(new bilansECTS(readerFieldFromSylabus["Nazwa"].ToString(), "", ""));
                }
                if (readerFieldFromSylabus["Godziny"] != null && readerFieldFromSylabus["ECTS"] != null)
                {
                    balances.Add(new bilansECTS(readerFieldFromSylabus["Nazwa"].ToString(), readerFieldFromSylabus["Godziny"].ToString(), readerFieldFromSylabus["ECTS"].ToString()));
                }

            }
            readerFieldFromSylabus.Close();


        }

        // Metody pobierające dane z struktur pomocniczych
        public string getECTSName(int index)
        {
            return balances[index].name;
        }
        public string getECTSHours(int index)
        {
            return balances[index].hours;
        }
        public string getECTS(int index)
        {
            return balances[index].ects;
        }
        public int getBalancesCount()
        {
            return balances.Count;
        }
        public string getCourseName(int index)
        {
            return course[index].courseName;
        }
        public string getDescContent(int index)
        {
            return course[index].descContent;
        }
        public string getBasicLiterature(int index)
        {
            return course[index].basicLiterature;
        }
        public string getAdditionalLiterature(int index)
        {
            return course[index].additionalLiterature;
        }
        public string getTeachingMethors(int index)
        {
            return course[index].teachingMethods;
        }
        public string getNameOfForm(int index)
        {
            return course[index].nameOfForm;
        }
        public string getCountOfHours(int index)
        {
            return course[index].countOfHours;
        }
        public string getInstructorName(int index)
        {
            return course[index].instructorName;
        }
        public string getInstructorSurName(int index)
        {
            return course[index].instructorSurName;
        }
        public string getWayOfEvaluting(int index)
        {
            return course[index].wayOfEvaluating;
        }
        public string getEvEffectModule(int index)
        {
            return course[index].evEffectModule;
        }
        public string getScaleRatings(int index)
        {
            return course[index].scaleRatings;
        }
        public int getCourseCount()
        {
            return course.Count;
        }
        private struct bilansECTS
        {
            public string name { get; private set; }
            public string hours { get; private set; }
            public string ects { get; private set; }

            public bilansECTS(string name, string hours, string ects)
            {
                this.name = name;
                this.hours = hours;
                this.ects = ects;
            }

        }
        private struct contentOfEducation
        {
            public string courseName { get; private set; }
            public string descContent { get; private set; }
            public string basicLiterature { get; private set; }
            public string additionalLiterature { get; private set; }
            public string teachingMethods { get; private set; }
            public string nameOfForm { get; private set; }
            public string countOfHours { get; private set; }
            public string instructorName { get; private set; }
            public string instructorSurName { get; private set; }
            public string wayOfEvaluating { get; private set; }
            public string evEffectModule { get; private set; }
            public string scaleRatings { get; private set; }

            public contentOfEducation(string courseName, string descContent, string basicLiterature, string additionalLiterature, string teachingMethods, string nameOfForm, string countOfHours, string instructorName, string instructorSurName, string wayOfEvaluating, string evEffectModule, string scaleRatings)
            {
                this.courseName = courseName;
                this.descContent = descContent;
                this.basicLiterature = basicLiterature;
                this.additionalLiterature = additionalLiterature;
                this.teachingMethods = teachingMethods;
                this.nameOfForm = nameOfForm;
                this.countOfHours = countOfHours;
                this.instructorName = instructorName;
                this.instructorSurName = instructorSurName;
                this.wayOfEvaluating = wayOfEvaluating;
                this.evEffectModule = evEffectModule;
                this.scaleRatings = scaleRatings;
            }
        }
    }

}
