using AutoMapper;
using System;

namespace Theater.Mapper
{
    public class BaseMapper<TDomain,TData>
        where TDomain:class
        where TData:class
    {
        private TDomain domain;
        private TData data;
        protected IMappingExpression<TDomain, TData> mappingExpression;
        protected MapperConfiguration config;

        protected BaseMapper(TDomain domain)
        {
            this.config = new MapperConfiguration(cfg =>
            {
               this.mappingExpression = cfg.CreateMap<TDomain, TData>();
            });

            this.Reconfig(this.mappingExpression);

            this.domain = domain;
            IMapper iMapper = config.CreateMapper();
            this.data = iMapper.Map<TDomain, TData>(this.domain);
        }

        public TDomain Domain
        {
            get { return this.domain; }
        }

        public TData Data
        {
            get { return this.data; }
        }

        protected virtual void Reconfig(IMappingExpression<TDomain, TData> mappingExpression)
        {

        }
    }
}
