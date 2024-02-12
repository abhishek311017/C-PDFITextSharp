using System;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using ListItem = iTextSharp.text.ListItem;
using Rectangle = iTextSharp.text.Rectangle;

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

            Font fontH1 = new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.BOLD, BaseColor.BLACK);
            Font fontH2 = new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.NORMAL, BaseColor.BLACK);
            Font fontH3 = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.BOLDITALIC, BaseColor.RED);
            Font fontH4 = new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.BOLDITALIC, BaseColor.BLACK);
            Font fontH5 = new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL, BaseColor.BLACK);
            Font fontH6 = new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.BOLD, BaseColor.BLACK);
            Font font = new Font(FontFactory.GetFont("Arial", 7f, Font.NORMAL));
            fontH6.SetStyle(Font.UNDERLINE);
           // fontH6.SetStyle(Font.BOLD);

            PdfPTable T14 = new PdfPTable(5);
            PdfPTable T15 = new PdfPTable(5);
            PdfPTable T16 = new PdfPTable(2);
            PdfPTable T17 = new PdfPTable(2);
            PdfPTable T18 = new PdfPTable(1);
            PdfPTable T19 = new PdfPTable(1);
            PdfPTable T20 = new PdfPTable(1);
            PdfPTable T21 = new PdfPTable(1);
            PdfPTable T22 = new PdfPTable(1);
            PdfPTable T23 = new PdfPTable(1);
            PdfPTable T24 = new PdfPTable(1);
            T14.WidthPercentage = 96.5f;
            T15.WidthPercentage = 96.5f;
            T16.WidthPercentage = 96.5f;
            T17.WidthPercentage = 96.5f;
            T18.WidthPercentage = 88;
            T19.WidthPercentage = 96.5f;
            T20.WidthPercentage = 96.5f;
            T21.WidthPercentage = 96.5f;
            T22.WidthPercentage = 96.5f;
            T23.WidthPercentage = 96.5f;
            T24.WidthPercentage = 96.5f;

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
            T10.SpacingAfter = 5;

            //fouth row
            PdfPCell cell38 = (new PdfPCell(new Phrase("Total of Section A Must Match Total of Section B ", new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.BOLD))));
            PdfPTable T11 = new PdfPTable(5);
            T11.WidthPercentage = 96.5f;
            cell38.PaddingBottom = 5f;
            cell38.Colspan = 4;
            cell38.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell38.HorizontalAlignment = 1;
            cell38.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell38.BorderWidth = 1f;
            T11.AddCell(cell38);
            PdfPCell cell39 = (new PdfPCell(new Phrase("9", font)));
            cell39.Colspan = 1;
            cell39.HorizontalAlignment = Element.ALIGN_CENTER;
            cell39.VerticalAlignment = Element.ALIGN_TOP;
            T11.AddCell(cell39);

          
            //Create Phrase Object (Data, Font object)
            Phrase ph4 = new Phrase("Section B: Tax Information", new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, BaseColor.BLACK));
            PdfPTable T12 = new PdfPTable(1);
            //Create Cell using Phrase object
            PdfPCell cell40 = new PdfPCell(ph4);
            T12.WidthPercentage = 96.5f;
            cell40.Colspan = 2;
            cell40.FixedHeight = 18.0f;
            cell40.HorizontalAlignment = 1;
            cell40.VerticalAlignment = 1;
            cell40.BackgroundColor = BaseColor.GRAY;
            T12.AddCell(cell40);

            PdfPTable T13 = new PdfPTable(5);
            T13.WidthPercentage = 96.5f;
            //T13.AddCell(new PdfPCell(new Phrase("Location", fontH1)));
            //T13.AddCell(new PdfPCell(new Phrase("Sticks Per Pack", fontH1)));
            //T13.AddCell(new PdfPCell(new Phrase("# of Pack(s) State Tax Paid", fontH1)));
            //T13.AddCell(new PdfPCell(new Phrase("# of Pack(s) Local Tax Paid", fontH1)));
            //T13.AddCell(new PdfPCell(new Phrase("# of Pack(s) No State Tax Paid", fontH1)));
            //T13.AddCell(new PdfPCell(new Phrase("ALASKA", fontH2)));
            //T13.AddCell(new PdfPCell(new Phrase("20", fontH2)));
            //T13.AddCell(new PdfPCell(new Phrase("7", fontH2)));
            //T13.AddCell(new PdfPCell(new Phrase("", fontH2)));
            //T13.AddCell(new PdfPCell(new Phrase("", fontH2)));
            //T13.AddCell(new PdfPCell(new Phrase("ALASKA", fontH2)));
            //T13.AddCell(new PdfPCell(new Phrase("20", fontH2)));
            //T13.AddCell(new PdfPCell(new Phrase("2", fontH2)));
            //T13.AddCell(new PdfPCell(new Phrase("", fontH2)));
            //T13.AddCell(new PdfPCell(new Phrase("", fontH2)));

            PdfPCell cell75 = (new PdfPCell(new Phrase("Location", fontH1)));
            cell75.HorizontalAlignment = 1;
            cell75.VerticalAlignment = 1;
            cell75.FixedHeight = 18.0f;
            cell75.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cell61 = (new PdfPCell(new Phrase("Sticks Per Pack", fontH1)));
            cell61.HorizontalAlignment = 1;
            cell61.VerticalAlignment = 1;
            cell61.FixedHeight = 18.0f;
            cell61.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cell62 = (new PdfPCell(new Phrase("# of Pack(s) State Tax Paid", fontH1)));
            cell62.HorizontalAlignment = 1;
            cell62.VerticalAlignment = 1;
            cell62.FixedHeight = 18.0f;
            cell62.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cell63 = (new PdfPCell(new Phrase("# of Pack(s) Local Tax Paid", fontH1)));
            cell63.HorizontalAlignment = 1;
            cell63.VerticalAlignment = 1;
            cell63.FixedHeight = 18.0f;
            cell63.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cell64 = (new PdfPCell(new Phrase("# of Pack(s) No State Tax Paid", fontH1)));
            cell64.HorizontalAlignment = 1;
            cell64.VerticalAlignment = 1;
            cell64.FixedHeight = 18.0f;
            cell64.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cell65 = (new PdfPCell(new Phrase("ALASKA", fontH2)));
            cell65.HorizontalAlignment = 1;
            cell65.VerticalAlignment = 1;
            cell65.FixedHeight = 18.0f;
            PdfPCell cell66 = (new PdfPCell(new Phrase("20", fontH2)));
            cell66.HorizontalAlignment = 1;
            cell66.VerticalAlignment = 1;
            cell66.FixedHeight = 18.0f;
            PdfPCell cell67 = (new PdfPCell(new Phrase("7", fontH2)));
            cell67.HorizontalAlignment = 1;
            cell67.VerticalAlignment = 1;
            cell67.FixedHeight = 18.0f;
            PdfPCell cell68 = (new PdfPCell(new Phrase("", fontH2)));
            cell68.FixedHeight = 18.0f;
            PdfPCell cell69 = (new PdfPCell(new Phrase("", fontH2)));
            cell69.FixedHeight = 18.0f;
            PdfPCell cell70 = (new PdfPCell(new Phrase("ALASKA", fontH2)));
            cell70.FixedHeight = 18.0f;
            cell70.HorizontalAlignment = 1;
            cell70.VerticalAlignment = 1;
            PdfPCell cell71 = (new PdfPCell(new Phrase("20", fontH2)));
            cell71.HorizontalAlignment = 1;
            cell71.FixedHeight = 18.0f;
            cell71.VerticalAlignment = 1;
            PdfPCell cell72 = (new PdfPCell(new Phrase("2", fontH2)));
            cell72.HorizontalAlignment = 1;
            cell72.FixedHeight = 18.0f;
            cell72.VerticalAlignment = 1;
            PdfPCell cell73 = (new PdfPCell(new Phrase("", fontH2)));
            cell73.FixedHeight = 18.0f;
            PdfPCell cell74 = (new PdfPCell(new Phrase("", fontH2)));
            cell74.FixedHeight = 18.0f;
            T14.AddCell(cell75);
            T14.AddCell(cell61);
            T14.AddCell(cell62);
            T14.AddCell(cell63);
            T14.AddCell(cell64);
            T14.AddCell(cell65);
            T14.AddCell(cell66);
            T14.AddCell(cell67);
            T14.AddCell(cell68);
            T14.AddCell(cell69);
            T14.AddCell(cell70);
            T14.AddCell(cell71);
            T14.AddCell(cell72);
            T14.AddCell(cell73);
            T14.AddCell(cell74);

            PdfPCell cell42 = (new PdfPCell(new Phrase("State Total", new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.BOLD))));
            cell42.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell42.HorizontalAlignment = 1;
            cell75.FixedHeight = 18.0f;
            cell42.VerticalAlignment = 1;
            T14.AddCell(cell42);
            PdfPCell cell43 = (new PdfPCell(new Phrase("", new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.NORMAL))));
            cell43.BackgroundColor = BaseColor.GRAY;
            cell43.FixedHeight = 18.0f;
            T14.AddCell(cell43);
            PdfPCell cell76 = (new PdfPCell(new Phrase("9", fontH1)));
            cell76.HorizontalAlignment = 1;
            cell76.FixedHeight = 18.0f;
            cell76.VerticalAlignment = 1;
            T14.AddCell(cell76);
            PdfPCell cell44 = (new PdfPCell(new Phrase("", new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.NORMAL))));
            cell44.BackgroundColor = BaseColor.GRAY;
            cell44.FixedHeight = 18.0f;
            T14.AddCell(cell44);
            T14.AddCell(new PdfPCell(new Phrase("", fontH1)));

            //fouth row
            PdfPCell cell46 = (new PdfPCell(new Phrase("Total of Section B (State Tax Paid + Non State Tax Paid) Must Match Total Section A ", new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.BOLD))));
            cell46.Colspan = 4;
            cell46.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell46.HorizontalAlignment = 1;
            cell46.VerticalAlignment = 1;
            T15.AddCell(cell46);
            PdfPCell cell47 = (new PdfPCell(new Phrase("9", new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.BOLD))));
            cell47.Colspan = 1;
            cell47.HorizontalAlignment = 1;
            cell47.VerticalAlignment = 1;
            T15.AddCell(cell47);
            T15.SpacingAfter = 25;

            Phrase ph5 = new Phrase("DIRECT DISTRIBUTOR ACKNOWLEDGEMENT FIELDS MUST BE COMPLETED FOR CREDIT TO BE GENERATED", fontH3);

            //Create Cell using Phrase object
            PdfPCell cell48 = new PdfPCell(ph5);
            cell48.Colspan = 2;
            cell48.BorderWidth = 2;
            cell48.HorizontalAlignment = 1;
            cell48.VerticalAlignment = 1;
            cell48.FixedHeight = 17.0f;
            cell48.BorderWidth = 1.5f;
            cell48.BackgroundColor = BaseColor.LIGHT_GRAY;
            T16.AddCell(cell48);
            T16.SpacingAfter = 1;

            Phrase ph6 = new Phrase("Direct Distributor Acknowledgement", fontH4);

            //Create Cell using Phrase object
            PdfPCell cell49 = new PdfPCell(ph6);
            cell49.Colspan = 2;
            cell49.Border = Rectangle.NO_BORDER;
            cell49.HorizontalAlignment = 1;
            cell49.VerticalAlignment = 1;
            cell49.FixedHeight = 17.0f;
            cell49.BackgroundColor = BaseColor.LIGHT_GRAY;
            T17.AddCell(cell49);
            T17.SpacingAfter = 10;

            Phrase p1 = new Phrase("By acknowledging below, the Direct Distributor agrees that the information provided in Sections A & B is accurate to the best of their knowledge. In addition,the Direct Distributor agrees to allow Philip Morris USA to process the product returned in accordance with the Philip Morris USA Returned Goods Policy. ", fontH5);
            PdfPCell cell50 = new PdfPCell(p1);
            cell50.Border = Rectangle.NO_BORDER;
            cell50.HorizontalAlignment = 1;
            cell50.VerticalAlignment = 1;
            T18.AddCell(cell50);
            T18.SpacingAfter = 10;


            Phrase ph7 = new Phrase(" ", new Font(Font.FontFamily.TIMES_ROMAN, 1f, Font.BOLD, BaseColor.BLACK));

            //Create Cell using Phrase object
            PdfPCell cell51 = new PdfPCell(ph7);
            cell51.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell51.BorderWidth = 1;
            T19.AddCell(cell51);
            T19.SpacingAfter = 10;

            //nested tables
            PdfPTable nested5 = new PdfPTable(6);


            Paragraph ph9 = (new Paragraph("I have reviewed the information contained in this PM USA Returned Goods Authorization" +
                " Form(and all attachments) and I certify that it is accurate by selecting the box.I agree to theterms of the PM USA Returned" +
                " Goods Policy and I am authorized to do so on behalf of theDirect Distributor listed on this document.", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL)));
            PdfPCell cell54 = (new PdfPCell(ph9));
            cell54.HorizontalAlignment = Element.ALIGN_LEFT;
            cell54.VerticalAlignment = Element.ALIGN_LEFT;
            cell54.Colspan = 4;
            cell54.Rowspan = 4;
            cell54.Border = Rectangle.NO_BORDER;
            nested5.AddCell(cell54);


            PdfPCell cell55 = (new PdfPCell(new Phrase("Direct Distributor Representative (Type in your name)", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL))));
            cell55.Border = Rectangle.NO_BORDER;
            nested5.AddCell(cell55);

            PdfPCell cell56 = (new PdfPCell(new Phrase("test test", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL))));
            nested5.AddCell(cell56);

            PdfPCell cell57 = (new PdfPCell(new Phrase("Date:", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL))));
            cell57.Border = Rectangle.NO_BORDER;
            nested5.AddCell(cell57);

            PdfPCell cell58 = (new PdfPCell(new Phrase("10/17/2022", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL))));
            nested5.AddCell(cell58);


            PdfPCell nesthousing5 = new PdfPCell(nested5);
            nesthousing5.BorderWidth = 1;
            nesthousing5.PaddingBottom = 8;
            nesthousing5.Border = Rectangle.NO_BORDER;
            T20.AddCell(nesthousing5);
            T20.SpacingAfter = 2;

            Phrase ph8 = new Phrase(" ", new Font(Font.FontFamily.TIMES_ROMAN, 1f, Font.BOLD, BaseColor.BLACK));

            //Create Cell using Phrase object
            PdfPCell cell53 = new PdfPCell(ph8);
            cell53.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell53.BorderWidth = 1;
            T21.AddCell(cell53);
            T21.SpacingAfter = 1000;

            Phrase ph12 = new Phrase("PACKAGING INSTRUCTIONS:", fontH6);
            PdfPCell cell77 = new PdfPCell(ph12);
            cell77.Border = Rectangle.NO_BORDER;
            cell77.PaddingTop = 30;
            T23.AddCell(cell77);

            List list1 = new List(List.UNORDERED);
            list1.SetListSymbol("\u2022");
            list1.IndentationLeft = 30f;
            list1.Add(new ListItem(" Do not bind the product together. Place individual packs in cartons or neatly stack in boxes. Each carton should only contain product of the same quantity, price,category and tax jurisdiction.Do not mix the product in carton.Excise Tax Recovery Returns need only be separated by quantity, product deal and tax jurisdiction. ", fontH5));
            list1.Add(new ListItem("Any product that appears to have been exposed to strong odors, foreign matter, infestation or excessive moisture should be isolated wrapped in plastic, and packagedseparately.", fontH5));
            list1.Add(new ListItem("Shipping boxes should be in good condition. If re-using boxes, remove all old or existing labels or markings.", fontH5));
            list1.Add(new ListItem("All boxes need to be labeled with the corresponding RGA number and sequentially number (1 of X, 2 of X)", fontH5));
            list1.Add(new ListItem("Place the approved Returned Goods Authorization Form and any supporting documentation (ex. Authorized Concealed Damage Form) inside product shipment box 1 ofX and keep a copy for your files. ", fontH5));
            list1.Add(new ListItem("Validate counts. In the event of a discrepancy, the Philip Morris USA Returned Goods Department's count will be final.", fontH5));
            list1.Add(new ListItem("The completed form must be included with the shipment.", fontH5));

            Phrase ph13 = new Phrase("SHIPPING INSTRUCTIONS:", fontH6);
            PdfPCell cell80 = new PdfPCell(ph13);
            cell80.Border = Rectangle.NO_BORDER;
            cell80.PaddingTop = 15;
            T24.AddCell(cell80);

          //  T24.AddCell(new PdfPCell(new Phrase("", fontH2)));

            List list2 = new List(List.UNORDERED);
            list2.SetListSymbol("\u2022");
            list2.IndentationLeft = 30f;
            list2.Add(new ListItem("Product must be returned via a Philip Morris USA approved carrier and must be classified as freight collect on the bill of lading ", fontH5));
            list2.Add(new ListItem("Multiple product returns may be shipped together as long as the paperwork and packaging for each product return is executed as instructed above", fontH5));

            Phrase ph10 = new Phrase("REFERENCE THE PHILIP MORRIS USA RETURNED GOODS POLICY AND INSTRUCTIONS FOR ADDITIONAL INFORMATION", new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.BOLD, BaseColor.BLACK));

            //Create Cell using Phrase object
            PdfPCell cell60 = new PdfPCell(ph10);
            cell60.Colspan = 2;
            cell60.HorizontalAlignment = 1;
            cell60.VerticalAlignment = 1;
            cell60.Border = Rectangle.NO_BORDER;
            cell60.PaddingTop = 20;

            T22.AddCell(cell60);


            PdfPTable tbfooter = new PdfPTable(3);
            tbfooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tbfooter.DefaultCell.Border = 0;
            tbfooter.AddCell(new Paragraph());
            tbfooter.AddCell(new Paragraph());
            var _cell2 = new PdfPCell(new Paragraph(new Chunk("Capitalized word and phases are defined in the Philip Morris USA Inc. Returned Goods Policy", new Font(Font.FontFamily.TIMES_ROMAN, 6f, Font.BOLD))));
            _cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
            _cell2.PaddingTop = 10;
            _cell2.Border = 0;
            tbfooter.AddCell(_cell2);
            tbfooter.AddCell(new Paragraph());
            tbfooter.AddCell(new Paragraph());
            var _celly = new PdfPCell(new Paragraph("Page" + writer.PageNumber.ToString() + "of " + (writer.PageNumber.ToString()), fontH5));//For page no.
            _celly.HorizontalAlignment = Element.ALIGN_CENTER;
            _celly.VerticalAlignment = Element.ALIGN_TOP;
           // _celly.PaddingTop = 10;
            _celly.Border = 0;
            tbfooter.AddCell(_celly);
            tbfooter.AddCell(new Paragraph());
            tbfooter.AddCell(new Paragraph());
            float[] widths1 = new float[] { 20f, 20f, 200f };
            tbfooter.SetWidths(widths1);
            tbfooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin), writer.DirectContent);

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
            document.Add(T11);
            document.Add(T12);
            document.Add(T13);
            document.Add(T14);
            document.Add(T15);
            document.Add(T16);
            document.Add(T17);
            document.Add(T18);
            document.Add(T19);
            document.Add(T20);
            document.Add(T21);
            document.NewPage();
            document.Add(T23);
            document.Add(list1);
            document.Add(T24);
            document.Add(list2);
            document.Add(T22);
            //document.Add(T23);
            //document.Add(T24);

            //PdfContentByte content1 = writer.DirectContent;
            //Rectangle rectangle1 = new Rectangle(document.PageSize);
            //rectangle.Left += document.LeftMargin;
            //rectangle.Right -= document.RightMargin;
            //rectangle.Top -= document.TopMargin;
            //rectangle.Bottom += document.BottomMargin;
            content.SetLineWidth(3);
            //content.SetColorStroke(BaseColor.BLACK);
            content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
            content.Stroke();
            tbfooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin), writer.DirectContent);
            //PdfPTable T7 = new PdfPTable(1);
            //PdfPCell cell32 = new PdfPCell(new Phrase("Line item details are at the end of RGA.", font));
            ////cell28.VerticalAlignment = 1;
            //cell32.Border = Rectangle.NO_BORDER;
            //cell32.PaddingLeft = 10;
            //T7.AddCell(cell32);
            //T7.SpacingBefore = 8;
            //document.Add(T7);
            document.Close();
        }
    }
}
