/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace MbzExtractor.dto
{
    [XmlRoot(ElementName = "detail")]
    public class Detail
    {
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "format")]
        public string Format { get; set; }
        [XmlElement(ElementName = "interactive")]
        public string Interactive { get; set; }
        [XmlElement(ElementName = "mode")]
        public string Mode { get; set; }
        [XmlElement(ElementName = "execution")]
        public string Execution { get; set; }
        [XmlElement(ElementName = "executiontime")]
        public string Executiontime { get; set; }
        [XmlAttribute(AttributeName = "backup_id")]
        public string Backup_id { get; set; }
    }

    [XmlRoot(ElementName = "details")]
    public class Details
    {
        [XmlElement(ElementName = "detail")]
        public Detail Detail { get; set; }
    }

    [XmlRoot(ElementName = "activity")]
    public class Activity
    {
        [XmlElement(ElementName = "moduleid")]
        public string Moduleid { get; set; }
        [XmlElement(ElementName = "sectionid")]
        public string Sectionid { get; set; }
        [XmlElement(ElementName = "modulename")]
        public string Modulename { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "directory")]
        public string Directory { get; set; }
    }

    [XmlRoot(ElementName = "activities")]
    public class Activities
    {
        [XmlElement(ElementName = "activity")]
        public List<Activity> Activity { get; set; }
    }

    [XmlRoot(ElementName = "section")]
    public class Section
    {
        [XmlElement(ElementName = "sectionid")]
        public string Sectionid { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "directory")]
        public string Directory { get; set; }
    }

    [XmlRoot(ElementName = "sections")]
    public class Sections
    {
        [XmlElement(ElementName = "section")]
        public List<Section> Section { get; set; }
    }

    [XmlRoot(ElementName = "course")]
    public class Course
    {
        [XmlElement(ElementName = "courseid")]
        public string Courseid { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "directory")]
        public string Directory { get; set; }
    }

    [XmlRoot(ElementName = "contents")]
    public class Contents
    {
        [XmlElement(ElementName = "activities")]
        public Activities Activities { get; set; }
        [XmlElement(ElementName = "sections")]
        public Sections Sections { get; set; }
        [XmlElement(ElementName = "course")]
        public Course Course { get; set; }
    }

    [XmlRoot(ElementName = "setting")]
    public class Setting
    {
        [XmlElement(ElementName = "level")]
        public string Level { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "settings")]
    public class Settings
    {
        [XmlElement(ElementName = "setting")]
        public List<Setting> Setting { get; set; }
    }

    [XmlRoot(ElementName = "information")]
    public class Information
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "moodle_version")]
        public string Moodle_version { get; set; }
        [XmlElement(ElementName = "moodle_release")]
        public string Moodle_release { get; set; }
        [XmlElement(ElementName = "backup_version")]
        public string Backup_version { get; set; }
        [XmlElement(ElementName = "backup_release")]
        public string Backup_release { get; set; }
        [XmlElement(ElementName = "backup_date")]
        public string Backup_date { get; set; }
        [XmlElement(ElementName = "mnet_remoteusers")]
        public string Mnet_remoteusers { get; set; }
        [XmlElement(ElementName = "include_files")]
        public string Include_files { get; set; }
        [XmlElement(ElementName = "include_file_references_to_external_content")]
        public string Include_file_references_to_external_content { get; set; }
        [XmlElement(ElementName = "original_wwwroot")]
        public string Original_wwwroot { get; set; }
        [XmlElement(ElementName = "original_site_identifier_hash")]
        public string Original_site_identifier_hash { get; set; }
        [XmlElement(ElementName = "original_course_id")]
        public string Original_course_id { get; set; }
        [XmlElement(ElementName = "original_course_format")]
        public string Original_course_format { get; set; }
        [XmlElement(ElementName = "original_course_fullname")]
        public string Original_course_fullname { get; set; }
        [XmlElement(ElementName = "original_course_shortname")]
        public string Original_course_shortname { get; set; }
        [XmlElement(ElementName = "original_course_startdate")]
        public string Original_course_startdate { get; set; }
        [XmlElement(ElementName = "original_course_enddate")]
        public string Original_course_enddate { get; set; }
        [XmlElement(ElementName = "original_course_contextid")]
        public string Original_course_contextid { get; set; }
        [XmlElement(ElementName = "original_system_contextid")]
        public string Original_system_contextid { get; set; }
        [XmlElement(ElementName = "details")]
        public Details Details { get; set; }
        [XmlElement(ElementName = "contents")]
        public Contents Contents { get; set; }
        [XmlElement(ElementName = "settings")]
        public Settings Settings { get; set; }
    }

    [XmlRoot(ElementName = "moodle_backup")]
    public class Moodle_backup
    {
        [XmlElement(ElementName = "information")]
        public Information Information { get; set; }
    }

}
