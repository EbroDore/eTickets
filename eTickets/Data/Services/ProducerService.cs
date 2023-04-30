using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
	public class ProducerService : EntityBaseRepository<Producer>, IProducerService
	{ 
		public ProducerService(ApplicationDbContext context) : base(context) { }
	}
}
