namespace student_api;

public interface IStudentService
{
    BaseResponse CreateStudent(CreateStudentRequest request);
    BaseResponse StudentList();
    BaseResponse GetStudentById(long id);
}
