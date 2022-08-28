using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MbzExtractor.constant;

namespace MbzExtractor.dto.inner
{
    [XmlRoot(ElementName = "activity")]
    public class ActivityFull
    {
        [XmlElement(ElementName = "assign")]
        public Assign Assign { get; set; }
        [XmlElement(ElementName = "resource")]
        public Resource Resource { get; set; }
        [XmlElement(ElementName = "folder")]
        public Folder Folder { get; set; }
        [XmlElement(ElementName = "label")]
        public Label Label { get; set; }
        [XmlElement(ElementName = "page")]
        public Page Page { get; set; }
        [XmlElement(ElementName = "url")]
        public Url Url { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "moduleid")]
        public string Moduleid { get; set; }
        [XmlAttribute(AttributeName = "modulename")]
        public string Modulename { get; set; }
        [XmlAttribute(AttributeName = "contextid")]
        public string Contextid { get; set; }

        [XmlIgnore]
        public EnumTypeActivity TypeActivity { get; set; }
    }


    [XmlRoot(ElementName = "submission")]
    public class Submission
    {
        [XmlElement(ElementName = "userid")]
        public string Userid { get; set; }
        [XmlElement(ElementName = "timecreated")]
        public string Timecreated { get; set; }
        [XmlElement(ElementName = "timemodified")]
        public string Timemodified { get; set; }
        [XmlElement(ElementName = "timestarted")]
        public string Timestarted { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "groupid")]
        public string Groupid { get; set; }
        [XmlElement(ElementName = "attemptnumber")]
        public string Attemptnumber { get; set; }
        [XmlElement(ElementName = "latest")]
        public string Latest { get; set; }

        [XmlElement(ElementName = "subplugin_assignsubmission_onlinetext_submission")]
        public Subplugin_assignsubmission_onlinetext_submission Subplugin_assignsubmission_onlinetext_submission { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "subplugin_assignsubmission_file_submission")]
        public Subplugin_assignsubmission_file_submission Subplugin_assignsubmission_file_submission { get; set; }
    }

    [XmlRoot(ElementName = "submission_onlinetext")]
    public class Submission_onlinetext
    {
        [XmlElement(ElementName = "onlinetext")]
        public string Onlinetext { get; set; }
        [XmlElement(ElementName = "onlineformat")]
        public string Onlineformat { get; set; }
        [XmlElement(ElementName = "submission")]
        public string Submission { get; set; }
    }

    [XmlRoot(ElementName = "subplugin_assignsubmission_onlinetext_submission")]
    public class Subplugin_assignsubmission_onlinetext_submission
    {
        [XmlElement(ElementName = "submission_onlinetext")]
        public Submission_onlinetext Submission_onlinetext { get; set; }
    }

    [XmlRoot(ElementName = "submission_file")]
    public class Submission_file
    {
        [XmlElement(ElementName = "numfiles")]
        public string Numfiles { get; set; }
        [XmlElement(ElementName = "submission")]
        public string Submission { get; set; }
    }

    [XmlRoot(ElementName = "subplugin_assignsubmission_file_submission")]
    public class Subplugin_assignsubmission_file_submission
    {
        [XmlElement(ElementName = "submission_file")]
        public Submission_file Submission_file { get; set; }
    }

    [XmlRoot(ElementName = "submissions")]
    public class Submissions
    {
        [XmlElement(ElementName = "submission")]
        public List<Submission> Submission { get; set; }
    }

    [XmlRoot(ElementName = "feedback_editpdf_files")]
    public class Feedback_editpdf_files
    {
        [XmlElement(ElementName = "gradeid")]
        public string Gradeid { get; set; }
    }

    [XmlRoot(ElementName = "pagerotation")]
    public class Pagerotation
    {
        [XmlElement(ElementName = "gradeid")]
        public string Gradeid { get; set; }
        [XmlElement(ElementName = "pageno")]
        public string Pageno { get; set; }
        [XmlElement(ElementName = "pathnamehash")]
        public string Pathnamehash { get; set; }
        [XmlElement(ElementName = "isrotated")]
        public string Isrotated { get; set; }
        [XmlElement(ElementName = "degree")]
        public string Degree { get; set; }
    }

    [XmlRoot(ElementName = "comment")]
    public class Comment
    {
        [XmlElement(ElementName = "gradeid")]
        public string Gradeid { get; set; }
        [XmlElement(ElementName = "pageno")]
        public string Pageno { get; set; }
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
        [XmlElement(ElementName = "width")]
        public string Width { get; set; }
        [XmlElement(ElementName = "rawtext")]
        public string Rawtext { get; set; }
        [XmlElement(ElementName = "colour")]
        public string Colour { get; set; }
        [XmlElement(ElementName = "draft")]
        public string Draft { get; set; }
    }

    [XmlRoot(ElementName = "feedback_editpdf_comments")]
    public class Feedback_editpdf_comments
    {
        [XmlElement(ElementName = "comment")]
        public List<Comment> Comment { get; set; }
    }

    [XmlRoot(ElementName = "feedback_editpdf_rotation")]
    public class Feedback_editpdf_rotation
    {
        [XmlElement(ElementName = "pagerotation")]
        public Pagerotation Pagerotation { get; set; }
    }

    [XmlRoot(ElementName = "feedback_file")]
    public class Feedback_file
    {
        [XmlElement(ElementName = "numfiles")]
        public string Numfiles { get; set; }
        [XmlElement(ElementName = "grade")]
        public string Grade { get; set; }
    }

    [XmlRoot(ElementName = "subplugin_assignfeedback_file_grade")]
    public class Subplugin_assignfeedback_file_grade
    {
        [XmlElement(ElementName = "feedback_file")]
        public Feedback_file Feedback_file { get; set; }
    }

    [XmlRoot(ElementName = "subplugin_assignfeedback_editpdf_grade")]
    public class Subplugin_assignfeedback_editpdf_grade
    {
        [XmlElement(ElementName = "feedback_editpdf_files")]
        public Feedback_editpdf_files Feedback_editpdf_files { get; set; }
        [XmlElement(ElementName = "feedback_editpdf_comments")]
        public Feedback_editpdf_comments Feedback_editpdf_comments { get; set; }
        [XmlElement(ElementName = "feedback_editpdf_rotation")]
        public Feedback_editpdf_rotation Feedback_editpdf_rotation { get; set; }
    }









    [XmlRoot(ElementName = "assign")]
    public class Assign
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "intro")]
        public string Intro { get; set; }
        [XmlElement(ElementName = "introformat")]
        public string Introformat { get; set; }
        [XmlElement(ElementName = "alwaysshowdescription")]
        public string Alwaysshowdescription { get; set; }
        [XmlElement(ElementName = "submissiondrafts")]
        public string Submissiondrafts { get; set; }
        [XmlElement(ElementName = "sendnotifications")]
        public string Sendnotifications { get; set; }
        [XmlElement(ElementName = "sendlatenotifications")]
        public string Sendlatenotifications { get; set; }
        [XmlElement(ElementName = "sendstudentnotifications")]
        public string Sendstudentnotifications { get; set; }
        [XmlElement(ElementName = "duedate")]
        public string Duedate { get; set; }
        [XmlElement(ElementName = "cutoffdate")]
        public string Cutoffdate { get; set; }
        [XmlElement(ElementName = "gradingduedate")]
        public string Gradingduedate { get; set; }
        [XmlElement(ElementName = "allowsubmissionsfromdate")]
        public string Allowsubmissionsfromdate { get; set; }
        [XmlElement(ElementName = "grade")]
        public string Grade { get; set; }
        [XmlElement(ElementName = "timemodified")]
        public string Timemodified { get; set; }
        [XmlElement(ElementName = "completionsubmit")]
        public string Completionsubmit { get; set; }
        [XmlElement(ElementName = "requiresubmissionstatement")]
        public string Requiresubmissionstatement { get; set; }
        [XmlElement(ElementName = "teamsubmission")]
        public string Teamsubmission { get; set; }
        [XmlElement(ElementName = "requireallteammemberssubmit")]
        public string Requireallteammemberssubmit { get; set; }
        [XmlElement(ElementName = "teamsubmissiongroupingid")]
        public string Teamsubmissiongroupingid { get; set; }
        [XmlElement(ElementName = "blindmarking")]
        public string Blindmarking { get; set; }
        [XmlElement(ElementName = "hidegrader")]
        public string Hidegrader { get; set; }
        [XmlElement(ElementName = "revealidentities")]
        public string Revealidentities { get; set; }
        [XmlElement(ElementName = "attemptreopenmethod")]
        public string Attemptreopenmethod { get; set; }
        [XmlElement(ElementName = "maxattempts")]
        public string Maxattempts { get; set; }
        [XmlElement(ElementName = "markingworkflow")]
        public string Markingworkflow { get; set; }
        [XmlElement(ElementName = "markingallocation")]
        public string Markingallocation { get; set; }
        [XmlElement(ElementName = "preventsubmissionnotingroup")]
        public string Preventsubmissionnotingroup { get; set; }
        [XmlElement(ElementName = "activity")]
        public string Activity { get; set; }
        [XmlElement(ElementName = "activityformat")]
        public string Activityformat { get; set; }
        [XmlElement(ElementName = "timelimit")]
        public string Timelimit { get; set; }
        [XmlElement(ElementName = "submissionattachments")]
        public string Submissionattachments { get; set; }

        [XmlElement(ElementName = "submissions")]
        public Submissions Submissions { get; set; }



        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "resource")]
    public class Resource
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "intro")]
        public string Intro { get; set; }
        [XmlElement(ElementName = "introformat")]
        public string Introformat { get; set; }
        [XmlElement(ElementName = "tobemigrated")]
        public string Tobemigrated { get; set; }
        [XmlElement(ElementName = "legacyfiles")]
        public string Legacyfiles { get; set; }
        [XmlElement(ElementName = "legacyfileslast")]
        public string Legacyfileslast { get; set; }
        [XmlElement(ElementName = "display")]
        public string Display { get; set; }
        [XmlElement(ElementName = "displayoptions")]
        public string Displayoptions { get; set; }
        [XmlElement(ElementName = "filterfiles")]
        public string Filterfiles { get; set; }
        [XmlElement(ElementName = "revision")]
        public string Revision { get; set; }
        [XmlElement(ElementName = "timemodified")]
        public string Timemodified { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "folder")]
    public class Folder
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "intro")]
        public string Intro { get; set; }
        [XmlElement(ElementName = "introformat")]
        public string Introformat { get; set; }
        [XmlElement(ElementName = "revision")]
        public string Revision { get; set; }
        [XmlElement(ElementName = "timemodified")]
        public string Timemodified { get; set; }
        [XmlElement(ElementName = "display")]
        public string Display { get; set; }
        [XmlElement(ElementName = "showexpanded")]
        public string Showexpanded { get; set; }
        [XmlElement(ElementName = "showdownloadfolder")]
        public string Showdownloadfolder { get; set; }
        [XmlElement(ElementName = "forcedownload")]
        public string Forcedownload { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "label")]
    public class Label
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "intro")]
        public string Intro { get; set; }
        [XmlElement(ElementName = "introformat")]
        public string Introformat { get; set; }
        [XmlElement(ElementName = "timemodified")]
        public string Timemodified { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "page")]
    public class Page
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "intro")]
        public string Intro { get; set; }
        [XmlElement(ElementName = "introformat")]
        public string Introformat { get; set; }
        [XmlElement(ElementName = "content")]
        public string Content { get; set; }
        [XmlElement(ElementName = "contentformat")]
        public string Contentformat { get; set; }
        [XmlElement(ElementName = "legacyfiles")]
        public string Legacyfiles { get; set; }
        [XmlElement(ElementName = "legacyfileslast")]
        public string Legacyfileslast { get; set; }
        [XmlElement(ElementName = "display")]
        public string Display { get; set; }
        [XmlElement(ElementName = "displayoptions")]
        public string Displayoptions { get; set; }
        [XmlElement(ElementName = "revision")]
        public string Revision { get; set; }
        [XmlElement(ElementName = "timemodified")]
        public string Timemodified { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "url")]
    public class Url
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "intro")]
        public string Intro { get; set; }
        [XmlElement(ElementName = "introformat")]
        public string Introformat { get; set; }
        [XmlElement(ElementName = "externalurl")]
        public string Externalurl { get; set; }
        [XmlElement(ElementName = "display")]
        public string Display { get; set; }
        [XmlElement(ElementName = "displayoptions")]
        public string Displayoptions { get; set; }
        [XmlElement(ElementName = "parameters")]
        public string Parameters { get; set; }
        [XmlElement(ElementName = "timemodified")]
        public string Timemodified { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }



}