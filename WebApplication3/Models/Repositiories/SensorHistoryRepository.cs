﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models.Database;
using WebApplication3.Models.Interfaces;

namespace WebApplication3.Models.Repositiories
{
    public class SensorHistoryRepository : ISensorHistoryRepository 
    {
        private readonly DatabaseContext _databaseContext;
        private SensorHistory sensorHistory;

        public SensorHistoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int AddHumiditySensorHistory(HumiditySensor sensor)
        {
            if (sensor == null)
            {
                throw new Exception("Sensore object cannot be null");
            }

            sensorHistory = new SensorHistory();

            sensorHistory.HouseId = sensor.HouseId;
            sensorHistory.SensorId = sensor.SensorId;
            sensorHistory.Type = sensor.Type;
            sensorHistory.Name = sensor.Name;
            sensorHistory.Humidity = sensor.Humidity;
            sensorHistory.IsOn = sensor.IsOn;

            _databaseContext.SensorHistories.Add(sensorHistory);
            _databaseContext.SaveChanges();

            return sensorHistory.SensorHistoryId;
        }

        public int AddMotionSensorHistory(MotionSensor sensor)
        {
            if (sensor == null)
            {
                throw new Exception("Sensore object cannot be null");
            }

            sensorHistory = new SensorHistory();

            sensorHistory.HouseId = sensor.HouseId;
            sensorHistory.SensorId = sensor.SensorId;
            sensorHistory.Type = sensor.Type;
            sensorHistory.Name = sensor.Name;
            sensorHistory.IsMove = sensor.IsMove;
            sensorHistory.IsOn = sensor.IsOn;

            _databaseContext.SensorHistories.Add(sensorHistory);
            _databaseContext.SaveChanges();
            
            return sensorHistory.SensorHistoryId;
        }

        public int AddSmokeSensorHistory(SmokeSensor sensor)
        {
            if (sensor == null)
            {
                throw new Exception("Sensore object cannot be null");
            }

            sensorHistory = new SensorHistory();

            sensorHistory.HouseId = sensor.HouseId;
            sensorHistory.SensorId = sensor.SensorId;
            sensorHistory.Type = sensor.Type;
            sensorHistory.Name = sensor.Name;
            sensorHistory.Smoke = sensor.Smoke;
            sensorHistory.IsOn = sensor.IsOn;

            _databaseContext.SensorHistories.Add(sensorHistory);
            _databaseContext.SaveChanges();

            return sensorHistory.SensorHistoryId;
        }

        public int AddTemperatureSensorHistory(TemperatureSensor sensor)
        {
            if (sensor == null)
            {
                throw new Exception("Sensore object cannot be null");
            }

            sensorHistory = new SensorHistory();
            
            sensorHistory.HouseId = sensor.HouseId;
            sensorHistory.SensorId = sensor.SensorId;
            sensorHistory.Type = sensor.Type;
            sensorHistory.Name = sensor.Name;
            sensorHistory.Temperature = sensor.Temperature;
            sensorHistory.IsOn = sensor.IsOn;

            _databaseContext.SensorHistories.Add(sensorHistory);
            _databaseContext.SaveChanges();

            return sensorHistory.SensorHistoryId;
        }

        public List<SensorHistory> GetAllSensorsHistory()
        {
            return _databaseContext.SensorHistories.ToList();
        }

        public SensorHistory GetSensorHistory(int sensorId)
        {
            if (sensorId <= 0)
            {
                throw new Exception("Id cannot be less than 0");
            }

            return _databaseContext.SensorHistories.FirstOrDefault(sensor => sensor.SensorId == sensorId);
        }

        public List<SensorHistory> GetSensorsByHouseIdHistory(int houseId)
        {
            if (houseId <= 0)
            {
                throw new Exception("Id cannot be less than 0");
            }

            return _databaseContext.SensorHistories.Where(id => id.HouseId == houseId).ToList();
        }

        public List<SensorHistory> GetTemperatureSensorsByHouseIdHistory(int houseId)
        {
            if (houseId <= 0)
            {
                throw new Exception("Id cannot be less than 0");
            }

            return _databaseContext.SensorHistories.Where(s => s.HouseId == houseId && s.Type == "Temperature").ToList();
        }

        public List<SensorHistory> GetHumiditySensorsByHouseIdHistory(int houseId)
        {
            if (houseId <= 0)
            {
                throw new Exception("Id cannot be less than 0");
            }

            return _databaseContext.SensorHistories.Where(s => s.HouseId == houseId && s.Type == "Humidity").ToList();
        }

        public List<SensorHistory> GetSmokeSensorsByHouseIdHistory(int houseId)
        {
            if (houseId <= 0)
            {
                throw new Exception("Id cannot be less than 0");
            }

            return _databaseContext.SensorHistories.Where(s => s.HouseId == houseId && s.Type == "Smoke").ToList();
        }

        public List<SensorHistory> GetMotionSensorsByHouseIdHistory(int houseId)
        {
            if (houseId <= 0)
            {
                throw new Exception("Id cannot be less than 0");
            }

            return _databaseContext.SensorHistories.Where(s => s.HouseId == houseId && s.Type == "Motion").ToList();
        }
    }
}
