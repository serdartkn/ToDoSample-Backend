using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDoDal;

        public ToDoManager(IToDoDal toDoDal)
        {
            _toDoDal = toDoDal;
        }

        public IResult Add(ToDo toDo)
        {
            _toDoDal.Add(toDo);
            return new SuccessResult(Messages.ToDoAdded);
        }

        public IResult Delete(ToDo toDo)
        {
            _toDoDal.Delete(toDo);
            return new SuccessResult(Messages.ToDoDeleted);
        }

        public IDataResult<List<ToDo>> GetAll()
        {
            return new SuccessDataResult<List<ToDo>>(_toDoDal.GetAll(), Messages.ToDoListed);
        }

        public IDataResult<ToDo> GetById(int id)
        {
            return new SuccessDataResult<ToDo>(_toDoDal.Get(td => td.Id == id), Messages.ToDoListed);
        }

        public IResult Update(ToDo toDo)
        {
            _toDoDal.Update(toDo);
            return new SuccessResult(Messages.ToDoUpdated);
        }
    }
}
