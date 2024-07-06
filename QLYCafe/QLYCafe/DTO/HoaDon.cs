﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DTO
{
    internal class HoaDon
    {
        public HoaDon(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int idBan, int status, int idKh, int idNv)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.IdBan = idBan;
            this.Status = status;
            this.IdKh = idKh;
            this.IdNv = idNv;
        }
        private int iD;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int idBan;
        private int status;
        private int idKh;
        private int idNv;

        public HoaDon(DataRow row)
        {
            this.iD = (int)row["id"];
            this.DateCheckIn = (DateTime)row["DateCheckIn"];

            var dateCheckOutTemp = row["DateCheckOut"];
            if(dateCheckOutTemp.ToString() != "")

            this.DateCheckOut = (DateTime)row["DateCheckOut"];

            this.IdBan = (int)row["idBan"];
            this.Status= (int)row["status"];
            this.IdKh = (int)row["idKH"];
            this.IdNv = (int)row["idNV"];
        }
        public int Id
        {
            get { return iD; }
            set { iD = value; }
        }

        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }
        public int IdBan
        {
            get { return idBan; }
            set { idBan = value; }
        }
        public int IdKh
        {
            get { return idKh; }
            set { idKh = value; }
        }
        public int IdNv
        {
            get { return idNv; }
            set { idNv = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
