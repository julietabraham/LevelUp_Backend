using Microsoft.EntityFrameworkCore;

namespace LevelUp_1.Model
{
    public class AssessmentRepository
    {
        internal async static Task<demo> GetQuestionsByDomId(int domainId)
        {
            using (var db = new LevelUpContext())
            {
                return await db.demo.
                    FirstOrDefaultAsync(domain => domain.DomainId == domainId); ;

            }
        }

        internal async static Task<List<QnA>> GetQnA(int domainId)
        {
            using (var db = new LevelUpContext())
            {
                return await db.QnA.Where(q => q.Domain_Id == domainId).ToListAsync(); ;
 ;

            }
        }
    }
}
