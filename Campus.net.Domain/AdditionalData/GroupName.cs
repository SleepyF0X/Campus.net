using Campus.net.Domain.MainData;
using System;

namespace Campus.net.Domain.AdditionalData
{
    public class GroupName
    {
        public Guid Id { get; }
        public Faculty Faculty { get; }
        public Specialization Specialization { get; }
        //Fuck this shit OMG
        /*Рассчет имени группы в зависимости от
         * 1. Факультета
         * 2. Кафедры
         * 3. Года поступления
         * 4. Номера по порядку
         * 5. Спецы
         * */
    }
}