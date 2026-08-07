using LibraryManagement.Model;

namespace LibraryManagement.Service;

public class MemberService
{
    private readonly List<Member> _members = new();

    public void AddMember(string memberName)
    {
        _members.Add(new Member
        {
            MemberId = _members.Count + 1,
            MemberName = memberName
        });
    }

    public List<Member> GetMembers()
    {
        return _members;
    }

    public Member? GetMemberById(int id)
    {
        return _members.FirstOrDefault(x => x.MemberId == id);
    }

    public bool DeleteMember(int id)
    {
        Member? member = GetMemberById(id);

        if (member != null)
        {
            _members.Remove(member);
            return true;
        }
        
        return false;
    }

    public List<Member> SearchMemberByName(string name)
    {
        return _members.Where(x => x.MemberName == name).ToList();
    }
}