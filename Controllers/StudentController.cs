using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentapi.Data;
using studentapi.Models;

namespace studentapi.Controllers
{//start of namespace
    [Route("api/[controller]")] //identifies the route for the controller, where [controller] is a placeholder for the controller name (Student in this case)
    [ApiController]
    public class StudentController : ControllerBase
    {// start of class StudentController
        private readonly AppDbContext context;
        //Creating a constructor for studentController
        public StudentController(AppDbContext context)
        {//start of constructor
            this.context = context;
        }//end of constructor

        //Creating GET method to get all students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentController>>> GetAll()
         {//start of GetAll method
            var students = await context.Students.ToListAsync();
            return Ok(students);
        }//end of GetAll method

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {//start of GetById method
            //Using the FindAsync method to find a student by id
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);

        }//end of GetById method

        //Creating POST method to create a new student
        [HttpPost]
        public async Task<ActionResult<Student>> Create(Student student)
        {//start of Create method
            context.Students.Add(student);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }//end of Create method

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student updatedStudent)
        {//start of Update method
            // checking if the id in the url matches the id of the student being updated
            if (id != updatedStudent.Id)
            { 
               return BadRequest();
            }
        
            context.Entry(updatedStudent).State = EntityState.Modified; //take all name,email,course and change the state to modified

            await context.SaveChangesAsync(); //save the changes to the database
            return NoContent(); //return no content to indicate that the update was successful
        }//end of Update method

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {//start of Delete method
         //Using the FindAsync method to find a student by id
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            context.Students.Remove(student); //remove the student from the database
            await context.SaveChangesAsync(); //save the changes to the database
            return NoContent(); //return no content to indicate that the deletion was successful
        }//end of Delete method
    }//end of class StudentController
}//end of namespace
