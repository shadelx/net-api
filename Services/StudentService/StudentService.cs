namespace student_api;

public class StudentService : IStudentService
{
    private readonly StudentContext context;

    public StudentService(StudentContext studentContext)
    {
        context = studentContext;
    }

    public BaseResponse CreateStudent(CreateStudentRequest request)
    {
        BaseResponse response;
        try
        {
            Student newStudent = new Student();
            newStudent.FirstName = request.first_name;
            newStudent.LastName = request.last_name;
            newStudent.Address = request.address;
            newStudent.Email = request.email;
            newStudent.ContactNumber = request.contact_number;

            using (context)
            {
                context.Add(newStudent);
                context.SaveChanges();
            }

            response = new BaseResponse
            {
                status_code = StatusCodes.Status200OK,
                data = new { message = "Successfully created the new student" }
            };

            return response;
        }
        catch (Exception ex)
        {
            response = new BaseResponse
            {
                status_code = StatusCodes.Status500InternalServerError,
                data = new { message = "Internal server error : " + ex.Message }
            };

            return response;
        }
    }

    public BaseResponse StudentList()
    {
        BaseResponse response;

        try
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (context)
            {
                context.Students.ToList().ForEach(student => students.Add(new StudentDTO
                {
                    id = student.Id,
                    first_name = student.FirstName,
                    last_name = student.LastName,
                    address = student.Address,
                    email = student.Email,
                    contact_number = student.ContactNumber
                }));
            }

            response = new BaseResponse
            {
                status_code = StatusCodes.Status200OK,
                data = new { students }
            };

            return response;
        }
        catch (Exception ex)
        {
            response = new BaseResponse
            {
                status_code = StatusCodes.Status500InternalServerError,
                data = new { message = "Internal server error : " + ex.Message }
            };

            return response;
        }

    }

    public BaseResponse GetStudentById(long id)
    {
        BaseResponse response;
        try
        {
            StudentDTO student = new StudentDTO();

            using (context)
            {
                Student filteredStudent = context.Students.Where(student => student.Id == id).FirstOrDefault();

                if (filteredStudent != null)
                {
                    student.id = filteredStudent.Id;
                    student.first_name = filteredStudent.FirstName;
                    student.address = filteredStudent.Address;
                    student.email = filteredStudent.Email;
                    student.contact_number = filteredStudent.ContactNumber;
                }
                else
                {
                    student = null;
                }
            }

            if (student != null)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { student }
                };
            }
            else
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status400BadRequest,
                    data = new { message = "No student found" }
                };
            }
            return response;

        }
        catch (Exception ex)
        {

            response = new BaseResponse
            {
                status_code = StatusCodes.Status500InternalServerError,
                data = new { message = "Internal server error : " + ex.Message }
            };

            return response;
        }

    }



}
