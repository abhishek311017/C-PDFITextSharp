using System;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFDownloadPractice.Controllers
{
    public class PdfHelper
    {
        public static void GeneratePdfTesting(String appPhysicalPath)
        {
            //physical path of file you want to create
            var filePath = appPhysicalPath + "\\RWS_WSL_PMUSAReturnRGAForm " + DateTime.Now.Ticks.ToString() + ".pdf";

            //Create Document
            var document = new Document();

            //Create Document Instance and load in 'document'
            var streamObj = new System.IO.FileStream(filePath, System.IO.FileMode.CreateNew);
            PdfWriter writer = PdfWriter.GetInstance(document, streamObj);
            document.Open();

            //to create border for a page
            PdfContentByte content = writer.DirectContent;
            Rectangle rectangle = new Rectangle(document.PageSize);
            rectangle.Left += document.LeftMargin;
            rectangle.Right -= document.RightMargin;
            rectangle.Top -= document.TopMargin;
            rectangle.Bottom += document.BottomMargin;
            content.SetLineWidth(3);
            content.SetColorStroke(BaseColor.BLACK);
            content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
            content.Stroke();
            
            //Font fontH1 = new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.BOLD, BaseColor.BLACK);
            //Font fontH2 = new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.NORMAL, BaseColor.BLACK);
            //Font fontH3 = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.BOLDITALIC, BaseColor.RED);
            //Font fontH4 = new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.BOLDITALIC, BaseColor.BLACK);
            //Font fontH5 = new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.NORMAL, BaseColor.BLACK);
            Font fontH6 = new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.BOLD, BaseColor.BLACK);
            Font font = new Font(FontFactory.GetFont("Arial", 7f, Font.NORMAL));
            fontH6.SetStyle(Font.UNDERLINE);


            PdfPTable pdfPTableEmpty = new PdfPTable(1);
            PdfPCell cell2 = new PdfPCell(new Phrase(" "));
            cell2.Border = 0;
            cell2.Colspan = 3;
            cell2.FixedHeight = 10.0f;
            pdfPTableEmpty.AddCell(cell2);
            document.Add(pdfPTableEmpty);

            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 96.5f;
            
            PdfPCell cellHeading = new PdfPCell(new Phrase("PM USA Returned Goods Authorization Form", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD)));
            cellHeading.FixedHeight = 18.0f;
            cellHeading.Border = 0;
            cellHeading.HorizontalAlignment = 1;
            cellHeading.VerticalAlignment = Element.ALIGN_TOP;
            cellHeading.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cellHeading);
            document.Add(table);

            PdfPCell cellShiptoCutomer = (new PdfPCell(new Phrase("Ship-to Customer #", font)));
            cellShiptoCutomer.Border = Rectangle.NO_BORDER;
            cellShiptoCutomer.HorizontalAlignment = 2;
            cellShiptoCutomer.PaddingRight = 7;
            cellShiptoCutomer.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellShiptoCutomerVal = (new PdfPCell(new Phrase("19308", font)));
            cellShiptoCutomerVal.VerticalAlignment = Element.ALIGN_TOP;
            cellShiptoCutomerVal.BorderColor = BaseColor.GRAY;
            cellShiptoCutomerVal.BorderWidth = 0.75f;

            PdfPCell cellDateCreated = new PdfPCell(new Phrase("Date Created ", font));
            cellDateCreated.Border = Rectangle.NO_BORDER;
            cellDateCreated.HorizontalAlignment = 2;
            cellDateCreated.PaddingRight = 7;
            cellDateCreated.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellDateCreatedVal = new PdfPCell(new Phrase("October 17, 2022", font));
            cellDateCreatedVal.VerticalAlignment = Element.ALIGN_TOP;
            cellDateCreatedVal.BorderColor = BaseColor.GRAY;
            cellDateCreatedVal.BorderWidth = 0.75f;
            
            PdfPCell cellRGA = new PdfPCell(new Phrase("RGA #", font));
            cellRGA.Border = Rectangle.NO_BORDER;
            cellRGA.PaddingLeft = 3;
            cellShiptoCutomer.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellRGAVal = new PdfPCell(new Phrase("B590ACBD8", font));
            cellRGAVal.VerticalAlignment = Element.ALIGN_TOP;
            cellRGAVal.BorderColor = BaseColor.GRAY;
            cellRGAVal.BorderWidth = 0.75f;

            PdfPCell cellContactName = new PdfPCell(new Phrase("Contact Name", font));
            cellContactName.Border = Rectangle.NO_BORDER;
            cellContactName.HorizontalAlignment = 2;
            cellContactName.PaddingRight = 7;
            cellContactName.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellContactNameVal = new PdfPCell(new Phrase("test test", font));
            cellContactNameVal.VerticalAlignment = Element.ALIGN_TOP;
            cellContactNameVal.BorderColor = BaseColor.GRAY;
            cellContactNameVal.BorderWidth = 0.75f;

            PdfPCell cellAccountName = new PdfPCell(new Phrase("Account Name ", font));
            cellAccountName.Border = Rectangle.NO_BORDER;
            cellAccountName.HorizontalAlignment = 2;
            cellAccountName.PaddingRight = 7;
            cellAccountName.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellAccountNameVal = new PdfPCell(new Phrase("MCLANE SOUTHWEST", font));
            cellAccountNameVal.VerticalAlignment = Element.ALIGN_TOP;
            cellAccountNameVal.BorderColor = BaseColor.GRAY;
            cellAccountNameVal.BorderWidth = 0.75f;

            PdfPCell cellDepot = new PdfPCell(new Phrase("Depot/Club #", font));
            cellDepot.Border = Rectangle.NO_BORDER;
            cellDepot.PaddingLeft = 3;
            cellDepot.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellDepotVal = new PdfPCell(new Phrase("", font));
            cellDepotVal.VerticalAlignment = Element.ALIGN_TOP;
            cellDepotVal.BorderColor = BaseColor.GRAY;
            cellDepotVal.BorderWidth = 0.75f;

            PdfPCell cellEmailAddress = new PdfPCell(new Phrase("E-Mail Address", font));
            cellEmailAddress.Border = Rectangle.NO_BORDER;
            cellEmailAddress.HorizontalAlignment = 2;
            cellEmailAddress.PaddingRight = 7;
            cellEmailAddress.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellEmailAddressVal = new PdfPCell(new Phrase("test@test.com", font));
            cellEmailAddressVal.VerticalAlignment = Element.ALIGN_TOP;
            cellEmailAddressVal.BorderColor = BaseColor.GRAY;
            cellEmailAddressVal.BorderWidth = 0.75f;

            PdfPCell cellAddress = new PdfPCell(new Phrase("Address", font));
            cellAddress.Border = Rectangle.NO_BORDER;
            cellAddress.HorizontalAlignment = 2;
            cellAddress.PaddingRight = 7;
            cellAddress.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellAddressVal = new PdfPCell(new Phrase("2828 Industrial Blvd Test1", font));
            cellAddressVal.VerticalAlignment = Element.ALIGN_TOP;
            cellAddressVal.BorderColor = BaseColor.GRAY;
            cellAddressVal.BorderWidth = 0.75f;

            PdfPCell cellContactPhone = new PdfPCell(new Phrase("Contact Phone # ", font));
            cellContactPhone.Border = Rectangle.NO_BORDER;
            cellContactPhone.HorizontalAlignment = 2;
            cellContactPhone.PaddingRight = 7;
            cellContactPhone.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellContactPhoneVal = new PdfPCell(new Phrase("(544)-444-4444", font));
            cellContactPhoneVal.VerticalAlignment = Element.ALIGN_TOP;
            cellContactPhoneVal.BorderColor = BaseColor.GRAY;
            cellContactPhoneVal.BorderWidth = 0.75f;

            PdfPCell cellCity = new PdfPCell(new Phrase("City, State, Zip Code", font));
            cellCity.Border = Rectangle.NO_BORDER;
            cellCity.HorizontalAlignment = 2;
            cellCity.PaddingRight = 7;
            cellCity.VerticalAlignment = Element.ALIGN_TOP;

            PdfPCell cellCityVal = new PdfPCell(new Phrase("Temple, TX, 76504-1000", font));
            cellCityVal.VerticalAlignment = Element.ALIGN_TOP;
            cellCityVal.BorderColor = BaseColor.GRAY;
            cellCityVal.BorderWidth = 0.75f;

            float[] colWidth1 = new float[] { 55f, 43f };
            PdfPTable PT1 = new PdfPTable(2);
            PT1.SetWidths(colWidth1);
            PT1.WidthPercentage = 98;
            PT1.AddCell((new PdfPCell(new Phrase("# of Cases in Shipment", font)) { Border = Rectangle.NO_BORDER, PaddingLeft = 2 }));
            PT1.AddCell((new PdfPCell(new Phrase("6", font)) { Border = Rectangle.BOX, PaddingTop = 3, VerticalAlignment = Element.ALIGN_TOP , BorderColor = BaseColor.GRAY , BorderWidth = 0.75f }));

            PdfPCell P17 = new PdfPCell(PT1);
            P17.BorderWidth = 1;
            P17.PaddingBottom = 15;
            P17.PaddingTop = 3;
            P17.PaddingRight = 3;
            P17.PaddingLeft = 5;

            PdfPTable T1 = new PdfPTable(7);
            T1.WidthPercentage = 95;
            float[] colWidth11 = new float[] { 13f, 17f, 15f, 20f, 2f, 14f, 11f };
            T1.SetWidths(colWidth11);
            PdfPCell pRowempty = new PdfPCell(new Phrase(" "));
            pRowempty.FixedHeight = 7;
            pRowempty.Border = 0;

            PdfPCell cell23 = (new PdfPCell(new Phrase("", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL))));
            PdfPTable T2 = new PdfPTable(1);
            cell23.Colspan = 4;
            cell23.Border = Rectangle.NO_BORDER;
            T2.AddCell(cell23);
            T2.SpacingAfter = 10;

            PdfPCell cellReturnOptions = new PdfPCell(new Phrase("Return Options", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD, BaseColor.BLACK)));
            PdfPTable T3 = new PdfPTable(1);
            T3.WidthPercentage = 96.5f;
            cellReturnOptions.PaddingBottom = 4f;
            cellReturnOptions.HorizontalAlignment = 1;
            cellReturnOptions.VerticalAlignment=(Element.ALIGN_MIDDLE);
            cellReturnOptions.BorderWidth = 1.5f;
            cellReturnOptions.BorderColor = BaseColor.BLUE;
            cellReturnOptions.BackgroundColor = BaseColor.GRAY;
            T3.AddCell(cellReturnOptions);

            PdfPTable T4 = new PdfPTable(4);
            T4.WidthPercentage = 94f;

            PdfPCell cellReturnType = (new PdfPCell(new Phrase("Return Type", font)));
            cellReturnType.Border = Rectangle.NO_BORDER;
            cellReturnType.PaddingLeft = 7;
            T4.AddCell(cellReturnType);

            PdfPCell cellConcealed = (new PdfPCell(new Phrase("Concealed Damage Return", font)));
            cellConcealed.BorderColor = BaseColor.GRAY;
            cellConcealed.BorderWidth = 0.75f;
            T4.AddCell(cellConcealed);

            PdfPCell cell28 = new PdfPCell(new Phrase("Line item details are at the end of RGA.", font));
            cell28.Border = Rectangle.NO_BORDER;
            cell28.PaddingLeft = 10;
            T4.AddCell(cell28);
            T4.SpacingBefore = 8;

            PdfPCell cell29 = (new PdfPCell(new Phrase("", font)));
            cell29.HorizontalAlignment = 1;
            cell29.Border = Rectangle.NO_BORDER;
            cell29.PaddingTop = 8;
            T4.AddCell(cell29);

            float[] colWidth4 = new float[] { 15f, 30f, 30f, 15f};
            T4.SetWidths(colWidth4);

            PdfPTable T5 = new PdfPTable(1);
            T5.WidthPercentage = 96.5f;
            PdfPCell nesthousingReturn = new PdfPCell(T4);
            nesthousingReturn.BorderWidth = 1.2f;
            nesthousingReturn.BorderColor = BaseColor.BLUE;
            nesthousingReturn.PaddingBottom = 8;
            T5.AddCell(nesthousingReturn);
            T5.SpacingAfter = 3;

            PdfPTable T6 = new PdfPTable(3);
            PdfPCell cell30 = new PdfPCell(new Phrase("*** Enter the Escalation Number Provided by AGDC HQ", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL)));
            cell30.PaddingLeft = 7;
            cell30.Border = Rectangle.NO_BORDER;
            T6.AddCell(cell30);

            PdfPCell cell31 = new PdfPCell(new Phrase("N/A", font));
            cell31.VerticalAlignment = Element.ALIGN_CENTER;
            cell31.BorderColor = BaseColor.GRAY;
            cell31.BorderWidth = 0.75f;
            T6.AddCell(cell31);

            PdfPCell cell32 = new PdfPCell(new Phrase("", font));
            cell32.HorizontalAlignment = 1;
            cell32.Border = Rectangle.NO_BORDER;
            T6.AddCell(cell32);

            PdfPTable T7 = new PdfPTable(3);
            PdfPCell cell33 = new PdfPCell(new Phrase("**** Special Return Description", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL)));
            cell33.PaddingLeft = 10;
            cell33.Border = Rectangle.NO_BORDER;
            T7.AddCell(cell33);

            PdfPCell cell34 = new PdfPCell(new Phrase("N/A", font));
            cell34.BorderColor = BaseColor.GRAY;
            cell34.BorderWidth = 0.75f;
            cell34.PaddingRight = 7;
            T7.AddCell(cell34);

            PdfPCell cell35 = (new PdfPCell(new Phrase("", font)));
            cell35.HorizontalAlignment = 1;
            cell35.Border = Rectangle.NO_BORDER;
            T7.AddCell(cell35);

            PdfPTable T8 = new PdfPTable(2);
            T8.WidthPercentage = 96.5f;
            float[] colWidth5 = new float[] { 32f, 20f, 3f };
            T6.SetWidths(colWidth5);
            T7.SetWidths(colWidth5);

            PdfPCell nesthousing2 = new PdfPCell(T6);
            nesthousing2.BorderWidth = 1.2f;
            nesthousing2.BorderColor = BaseColor.BLUE;
            nesthousing2.PaddingBottom = 8;
            nesthousing2.PaddingTop = 8;

            PdfPCell nesthousing3 = new PdfPCell(T7);
            nesthousing3.BorderWidth = 1.2f;
            nesthousing3.BorderColor = BaseColor.BLUE;
            nesthousing3.PaddingBottom = 8;
            nesthousing3.PaddingTop = 8;

            T8.AddCell(nesthousing2);
            T8.AddCell(nesthousing3);
            T8.SpacingAfter = 2.5f;

            PdfPCell cellSection = new PdfPCell(new Phrase("Section A: Product Information", new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, BaseColor.BLACK)));
            PdfPTable T9 = new PdfPTable(1);
            T9.WidthPercentage = 96.5f;
            cellSection.PaddingBottom = 5f;
            cellSection.HorizontalAlignment = 1;
            cellSection.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellSection.BorderWidth = 1f;
            cellSection.BorderWidthTop = 1.2f;
            cellSection.BorderColor = BaseColor.BLACK;
            cellSection.BackgroundColor = BaseColor.GRAY;
            T9.AddCell(cellSection);

            PdfPTable nestedRevenueTable = new PdfPTable(4);
            PdfPTable T10 = new PdfPTable(1);
            T10.WidthPercentage = 96.5f;
            T10.SpacingBefore = 2.5f;

            PdfPCell revenueCell = (new PdfPCell(new Phrase("Total Revenue / Open Stock (# of Packs) =", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.BOLD))));
            revenueCell.Border = Rectangle.NO_BORDER;
            revenueCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            nestedRevenueTable.AddCell(revenueCell);

            PdfPTable nestedtable = new PdfPTable(1);

            // Top spacing cell
            PdfPCell topSpacing = new PdfPCell();
            topSpacing.FixedHeight = 7f;
            topSpacing.Border = Rectangle.NO_BORDER;
            nestedtable.AddCell(topSpacing);

            // Middle cell with '9'
            PdfPCell revenueCellValue = new PdfPCell(new Phrase("9", font));
            revenueCellValue.BorderColor = BaseColor.GRAY;
            revenueCellValue.BorderWidth = 0.75f;
            revenueCellValue.HorizontalAlignment = Element.ALIGN_CENTER;
            revenueCellValue.VerticalAlignment = Element.ALIGN_MIDDLE;
            nestedtable.AddCell(revenueCellValue);

            // Bottom spacing cell
            PdfPCell bottomSpacing = new PdfPCell();
            bottomSpacing.FixedHeight = 7f;
            bottomSpacing.Border = Rectangle.NO_BORDER;
            nestedtable.AddCell(bottomSpacing);

            PdfPCell boxCell = new PdfPCell(nestedtable);
            boxCell.PaddingLeft = 5f;
            boxCell.PaddingRight = 10f;
            boxCell.Border = Rectangle.NO_BORDER;
            nestedRevenueTable.AddCell(boxCell);

            PdfPCell cell37 = new PdfPCell(new Phrase("", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL)));
            cell37.Border = Rectangle.NO_BORDER;
            cell37.Colspan = 2;
            nestedRevenueTable.AddCell(cell37);

            float[] colWidth6 = new float[] { 30f, 24f, 24.5f, 30 };
            nestedRevenueTable.SetWidths(colWidth6);
            PdfPCell nesthousing4 = new PdfPCell(nestedRevenueTable);
            nesthousing4.BorderWidth = 1;
            T10.AddCell(nesthousing4);
            T10.SpacingAfter = 2;

            PdfPCell cellShiptoCutomer11 = new PdfPCell(cellShiptoCutomer);
            PdfPCell cellShiptoCutomerVal11 = new PdfPCell(cellShiptoCutomerVal);
            PdfPCell cellDateCreated11 = new PdfPCell(cellDateCreated);
            PdfPCell cellDateCreatedVal11 = new PdfPCell(cellDateCreatedVal);
            PdfPCell pcolEmpty1 = (new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL))));
            PdfPCell cellRGA11 = new PdfPCell(cellRGA);
            PdfPCell cellRGAVal11 = new PdfPCell(cellRGAVal);
            PdfPCell cellContactName11 = new PdfPCell(cellContactName);
            PdfPCell cellContactNameVal11 = new PdfPCell(cellContactNameVal);
            PdfPCell cellAccountName11 = new PdfPCell(cellAccountName);
            PdfPCell cellAccountNameVal11 = new PdfPCell(cellAccountNameVal);
            PdfPCell cellDepot11 = new PdfPCell(cellDepot);
            PdfPCell cellDepotVal11 = new PdfPCell(cellDepotVal);
            PdfPCell cellEmailAddress11 = new PdfPCell(cellEmailAddress);
            PdfPCell cellEmailAddressVal11 = new PdfPCell(cellEmailAddressVal);
            PdfPCell cellAddress11 = new PdfPCell(cellAddress);
            PdfPCell cellAddressVal11 = new PdfPCell(cellAddressVal);
            PdfPCell P171 = new PdfPCell(new Phrase("17"));
            PdfPCell cellContactPhone11 = new PdfPCell(cellContactPhone);
            PdfPCell cellContactPhoneVal11 = new PdfPCell(cellContactPhoneVal);
            PdfPCell cellCity11 = new PdfPCell(cellCity);
            PdfPCell cellCityVal11 = new PdfPCell(cellCityVal);
            PdfPCell P22 = new PdfPCell(new Phrase(" "));
            PdfPCell P23 = new PdfPCell(new Phrase(" "));
            PdfPCell P24 = new PdfPCell(new Phrase(" "));
            P22.Border = Rectangle.NO_BORDER;
            P23.Border = Rectangle.NO_BORDER;
            P24.Border = Rectangle.NO_BORDER;

            pcolEmpty1.Border = 0;
            T1.AddCell(cellShiptoCutomer11);
            T1.AddCell(cellShiptoCutomerVal11);
            T1.AddCell(cellDateCreated11);
            T1.AddCell(cellDateCreatedVal11);
            T1.AddCell(pcolEmpty1);
            T1.AddCell(cellRGA11);
            T1.AddCell(cellRGAVal11);
            pRowempty.Colspan = 7;
            T1.AddCell(pRowempty);
            T1.AddCell(cellContactName11);
            T1.AddCell(cellContactNameVal11);
            T1.AddCell(cellAccountName11);
            T1.AddCell(cellAccountNameVal11);
            T1.AddCell(pcolEmpty1);
            T1.AddCell(cellDepot11);
            T1.AddCell(cellDepotVal11);
            pRowempty.Colspan = 7;
            T1.AddCell(pRowempty);
            T1.AddCell(cellEmailAddress11);
            T1.AddCell(cellEmailAddressVal11);
            T1.AddCell(cellAddress11);
            T1.AddCell(cellAddressVal11);
            T1.AddCell(pcolEmpty1);
            P17.Colspan = 2;
            P17.Rowspan = 3;
            T1.AddCell(P17);
            pRowempty.Colspan = 7;
            T1.AddCell(pRowempty);
            T1.AddCell(cellContactPhone11);
            T1.AddCell(cellContactPhoneVal11);
            T1.AddCell(cellCity11);
            T1.AddCell(cellCityVal11);
            T1.AddCell(P22);
            T1.AddCell(P23);
            T1.AddCell(P24);

            T1.SpacingBefore = 8.0f;
            document.Add(T1);
            document.Add(T2);
            document.Add(T3);
            document.Add(T5);
            document.Add(T8);
            document.Add(T9);
            document.Add(T10);
            document.NewPage();
            //PdfContentByte content1 = writer.DirectContent;
            //Rectangle rectangle1 = new Rectangle(doc1.PageSize);
            //rectangle.Left += doc1.LeftMargin;
            //rectangle.Right -= doc1.RightMargin;
            //rectangle.Top -= doc1.TopMargin;
            //rectangle.Bottom += doc1.BottomMargin;
            content.SetLineWidth(3);
            //content.SetColorStroke(BaseColor.BLACK);
            content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
            content.Stroke();
            //PdfPTable T7 = new PdfPTable(1);
            //PdfPCell cell32 = new PdfPCell(new Phrase("Line item details are at the end of RGA.", font));
            ////cell28.VerticalAlignment = 1;
            //cell32.Border = Rectangle.NO_BORDER;
            //cell32.PaddingLeft = 10;
            //T7.AddCell(cell32);
            //T7.SpacingBefore = 8;
            //doc1.Add(T7);
            document.Close();
        }
    }
}
