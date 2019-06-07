using System;
using System.Collections;
using System.Collections.Generic;

namespace src.DTO
{

    public class ListTimeLineDto
    {
        public ListTimeLineDto()
        {
            events = new List<TimeLineDto>();
        }
        public IList<TimeLineDto> events { get; set; }
    }
    public class TimeLineDto
    {
        
        public TimeLineDto(IList<EventDTO> custom_data)
        {
            
            this.custom_data = custom_data;

        }
        public DateTime timestamp { get; set; }
        public double revenue { get; set; }
        public IList<EventDTO> custom_data { get; set; }


    }

    public class EventDTO
    {
        public EventDTO()
        {
            
        }
        public string key { get; set; }
        public string value { get; set; }

    }
}