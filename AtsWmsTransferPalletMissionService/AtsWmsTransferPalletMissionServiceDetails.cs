using AtsWmsTransferPalletMissionService.ats_tata_metallics_dbDataSetTableAdapters;
using log4net;
using System;
using System.Timers;
using static AtsWmsTransferPalletMissionService.ats_tata_metallics_dbDataSet;

namespace AtsWmsTransferPalletMissionService
{
    internal class AtsWmsTransferPalletMissionServiceDetails
    {
        #region Data Tables

        ats_wms_transfer_pallet_mission_detailsDataTable ats_wms_transfer_pallet_mission_detailsDataTableDT = null;
        ats_wms_master_pallet_informationDataTable ats_wms_master_pallet_informationDataTableDT = null;
        ats_wms_transfer_pallet_mission_runtime_detailsDataTable ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableSourceDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableTargetDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableSourceFrontDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableTargetFrontDT = null;
        ats_wms_master_rack_detailsDataTable ats_wms_master_rack_detailsDataTableSourceDT = null;
        ats_wms_master_rack_detailsDataTable ats_wms_master_rack_detailsDataTableTargetDT = null;
        ats_wms_master_floor_detailsDataTable ats_wms_master_floor_detailsDataTableSourceDT = null;
        ats_wms_master_floor_detailsDataTable ats_wms_master_floor_detailsDataTableTargetDT = null;
        ats_wms_master_area_detailsDataTable ats_wms_master_area_detailsDataTableSourceDT = null;
        ats_wms_master_area_detailsDataTable ats_wms_master_area_detailsDataTableTargetDT = null;
        ats_wms_current_stock_detailsDataTable ats_wms_current_stock_detailsDataTableDT = null;
        ats_wms_master_shift_detailsDataTable ats_wms_master_shift_detailsDataTableDT = null;
        ats_wms_master_plc_connection_detailsDataTable ats_wms_master_plc_connection_detailsDataTableDT = null;
        ats_wms_current_stock_detailsDataTable ats_wms_current_stock_detailsDataTableDT2 = null;
        #endregion

        #region Table Adapters
        ats_wms_transfer_pallet_mission_detailsTableAdapter ats_wms_transfer_pallet_mission_detailsTableAdapterInstance = new ats_wms_transfer_pallet_mission_detailsTableAdapter();
        ats_wms_master_pallet_informationTableAdapter ats_wms_master_pallet_informationTableAdapterInstance = new ats_wms_master_pallet_informationTableAdapter();
        ats_wms_transfer_pallet_mission_runtime_detailsTableAdapter ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance = new ats_wms_transfer_pallet_mission_runtime_detailsTableAdapter();
        ats_wms_master_position_detailsTableAdapter ats_wms_master_position_detailsTableAdapterInstance = new ats_wms_master_position_detailsTableAdapter();
        ats_wms_master_rack_detailsTableAdapter ats_wms_master_rack_detailsTableAdapterInstance = new ats_wms_master_rack_detailsTableAdapter();
        ats_wms_master_floor_detailsTableAdapter ats_wms_master_floor_detailsTableAdapterInstance = new ats_wms_master_floor_detailsTableAdapter();
        ats_wms_master_area_detailsTableAdapter ats_wms_master_area_detailsTableAdapterInstance = new ats_wms_master_area_detailsTableAdapter();
        ats_wms_current_stock_detailsTableAdapter ats_wms_current_stock_detailsTableAdapterInstance = new ats_wms_current_stock_detailsTableAdapter();
        ats_wms_master_shift_detailsTableAdapter ats_wms_master_shift_detailsTableAdapterInstance = new ats_wms_master_shift_detailsTableAdapter();
        ats_wms_master_plc_connection_detailsTableAdapter ats_wms_master_plc_connection_detailsTableAdapterInstane = new ats_wms_master_plc_connection_detailsTableAdapter();

        #endregion

        #region Global Variables
        static string className = "AtsWmsTransferPalletMissionServiceDetails";
        private static readonly ILog Log = LogManager.GetLogger(className);
        private Timer AtsWmsTransferPalletMissionDetailsTimer = null;
        private string IP_ADDRESS = "192.168.0.1";
        bool conditionOne = false;
        bool conditionTwo = false;
        bool conditionThree = false;
        bool conditionFour = false;
        bool conditionFive = false;
        bool conditionSix = false;
        bool conditionThreeAlternate=false;
        bool conditionFourAlternate = false;
        #endregion

        public void startOperation()
        {
            try
            {
                Log.Debug("startOperation");
                //Timer 
                AtsWmsTransferPalletMissionDetailsTimer = new System.Timers.Timer();
                //Running the function after 1 sec 
                AtsWmsTransferPalletMissionDetailsTimer.Interval = (1000);
                //After 1 sec timer will elapse and DataFetchDetailsOperation function will be called 
                AtsWmsTransferPalletMissionDetailsTimer.Elapsed += new System.Timers.ElapsedEventHandler(AtsWmsTransferPalletMissionDetailsOperation);
                AtsWmsTransferPalletMissionDetailsTimer.AutoReset = false;
                AtsWmsTransferPalletMissionDetailsTimer.Start();

            }
            catch (Exception ex)
            {
                Log.Error("startOperation :: Exception Occure in AtsWmsTransferPalletMissionDetailsTimer" + ex.Message);
            }
        }

        private void AtsWmsTransferPalletMissionDetailsOperation(object sender, ElapsedEventArgs e)
        {
            try
            {
                try
                {

                    //Stopping the timer to start the below operation
                    AtsWmsTransferPalletMissionDetailsTimer.Stop();

                }
                catch (Exception ex)
                {
                    Log.Error("AtsWmsTransferPalletMissionDetailsTimer :: Exception occure while stopping the timer :: " + ex.Message + "StackTrace  :: " + ex.StackTrace);
                }



                //**************************************Buisness Logic**************************************



                //check (is mission Generated=0) and (isManualMission=1) in Transfer pallet Mission Details Table
                try
                {
                    ats_wms_transfer_pallet_mission_detailsDataTableDT = ats_wms_transfer_pallet_mission_detailsTableAdapterInstance.GetDataByIS_MISSION_GENERATEDAndIS_MANUAL_MISSION(0, 1);
                    Log.Debug("mission NOT generated");

                    //checking pallet information table data is available for same pallet information id 

                    if (ats_wms_transfer_pallet_mission_detailsDataTableDT != null && ats_wms_transfer_pallet_mission_detailsDataTableDT.Count > 0)
                    {
                        Log.Debug("1 :: ats_wms_transfer_pallet_mission_detailsDataTableDT.Count" + ats_wms_transfer_pallet_mission_detailsDataTableDT.Count);
                        //for (int i = 0; i <= ats_wms_master_pallet_informationDataTableDT.Count; i++)
                        for (int i = 0; i < ats_wms_transfer_pallet_mission_detailsDataTableDT.Count; i++)
                        {
                            Log.Debug("2");
                            try
                            {
                                String timeNow = DateTime.Now.TimeOfDay.ToString();
                                TimeSpan currentTimeNow = TimeSpan.Parse(timeNow);

                                String currentDate = "";
                                currentDate = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

                                Log.Debug("3");
                                //fetching pallet information id from pallet information table
                                ats_wms_master_pallet_informationDataTableDT = ats_wms_master_pallet_informationTableAdapterInstance.GetDataByPALLET_INFORMATION_ID(ats_wms_transfer_pallet_mission_detailsDataTableDT[i].PALLET_INFORMATION_ID);
                                Log.Debug("4");
                                //check data is available in db
                                if (ats_wms_master_pallet_informationDataTableDT != null && ats_wms_master_pallet_informationDataTableDT.Count > 0)
                                {
                                    Log.Debug("5");

                                    try
                                    {
                                        //check Transfer Management Mission status is 0
                                        if (ats_wms_transfer_pallet_mission_detailsDataTableDT[i].IS_MISSION_GENERATED == 0)
                                        {
                                            Log.Debug("6");
                                            //source data 
                                            #region Source Data
                                            //fetching previous position data
                                            try
                                            {
                                                ats_wms_master_position_detailsDataTableSourceDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_IDAndPOSITION_IS_ACTIVE(ats_wms_transfer_pallet_mission_detailsDataTableDT[i].POSITION_ID, 1);
                                                Log.Debug("7");
                                            }
                                            catch (Exception ex)
                                            {
                                                Log.Error(" Exception occured while fetching position id :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                            }

                                            if (ats_wms_master_position_detailsDataTableSourceDT != null && ats_wms_master_position_detailsDataTableSourceDT.Count > 0)
                                            {
                                                Log.Debug("8");
                                                try
                                                {
                                                    ats_wms_master_rack_detailsDataTableSourceDT = ats_wms_master_rack_detailsTableAdapterInstance.GetDataByRACK_IS_ACTIVEAndRACK_ID(1, ats_wms_master_position_detailsDataTableSourceDT[i].RACK_ID);
                                                    Log.Debug("9");
                                                }
                                                catch (Exception ex)
                                                {

                                                    Log.Error(" Exception occured while checking rack is active :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                                }
                                                if (ats_wms_master_rack_detailsDataTableSourceDT != null && ats_wms_master_rack_detailsDataTableSourceDT.Count > 0)
                                                    Log.Debug("10");
                                                {
                                                    try
                                                    {
                                                        ats_wms_master_floor_detailsDataTableSourceDT = ats_wms_master_floor_detailsTableAdapterInstance.GetDataByFLOOR_ID(ats_wms_master_position_detailsDataTableSourceDT[i].FLOOR_ID);
                                                        Log.Debug("11");
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Log.Error(" Exception occured while fetching floor id :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                                    }

                                                    if (ats_wms_master_floor_detailsDataTableSourceDT != null && ats_wms_master_floor_detailsDataTableSourceDT.Count > 0)
                                                        Log.Debug("12");
                                                    {
                                                        try
                                                        {
                                                            ats_wms_master_area_detailsDataTableSourceDT = ats_wms_master_area_detailsTableAdapterInstance.GetDataByAREA_ID(ats_wms_master_position_detailsDataTableSourceDT[i].AREA_ID);
                                                            Log.Debug("13");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.Error(" Exception occured while fetching area id :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                                        }
                                                    }

                                                }


                                            }
                                            #endregion

                                            //destination data
                                            #region Target Data
                                            // destination data
                                            try
                                            {
                                                ats_wms_master_position_detailsDataTableTargetDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_IDAndPOSITION_IS_ACTIVE(ats_wms_transfer_pallet_mission_detailsDataTableDT[i].TRANSFER_POSITION_ID, 1);
                                                Log.Debug("14");
                                            }
                                            catch (Exception ex)
                                            {
                                                Log.Error(" Exception occured while fetching position is active :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                            }

                                            if (ats_wms_master_position_detailsDataTableTargetDT != null && ats_wms_master_position_detailsDataTableTargetDT.Count > 0)
                                                Log.Debug("15");
                                            {
                                                try
                                                {
                                                    ats_wms_master_rack_detailsDataTableTargetDT = ats_wms_master_rack_detailsTableAdapterInstance.GetDataByRACK_IS_ACTIVEAndRACK_ID(1, ats_wms_master_position_detailsDataTableTargetDT[i].RACK_ID);
                                                    Log.Debug("16");
                                                }
                                                catch (Exception ex)
                                                {

                                                    Log.Error(" Exception occured while checking rack is active :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                                }
                                                if (ats_wms_master_rack_detailsDataTableTargetDT != null && ats_wms_master_rack_detailsDataTableTargetDT.Count > 0)
                                                    Log.Debug("17");
                                                {
                                                    try
                                                    {
                                                        ats_wms_master_floor_detailsDataTableTargetDT = ats_wms_master_floor_detailsTableAdapterInstance.GetDataByFLOOR_ID(ats_wms_master_position_detailsDataTableTargetDT[i].FLOOR_ID);
                                                        Log.Debug("18");
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Log.Error(" Exception occured while fetching floor id :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                                    }

                                                    if (ats_wms_master_floor_detailsDataTableTargetDT != null && ats_wms_master_floor_detailsDataTableTargetDT.Count > 0)
                                                        Log.Debug("19");
                                                    {
                                                        try
                                                        {
                                                            ats_wms_master_area_detailsDataTableTargetDT = ats_wms_master_area_detailsTableAdapterInstance.GetDataByAREA_ID(ats_wms_master_position_detailsDataTableTargetDT[i].AREA_ID);
                                                            Log.Debug("20");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.Error(" Exception occured while fetching area id :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                                        }
                                                    }

                                                }
                                            }
                                            #endregion


                                            try
                                            {
                                                ats_wms_current_stock_detailsDataTableDT = ats_wms_current_stock_detailsTableAdapterInstance.GetDataByPALLET_INFORMATION_ID(ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);
                                                Log.Debug("transferPalletMissionDetailsOperation :: Start inserting transfer pallet mission details for Pallet information ID :: " + ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);
                                                if (ats_wms_current_stock_detailsDataTableDT != null && ats_wms_current_stock_detailsDataTableDT.Count > 0)
                                                {
                                                    Log.Debug("Source PALLET_INFORMATION_ID :: " + ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);
                                                    Log.Debug("Source POSITION_ID :: " + ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID);
                                                    Log.Debug("Source RACK_ID :: " + ats_wms_master_rack_detailsDataTableSourceDT[0].RACK_ID);
                                                    Log.Debug("Source FLOOR_ID :: " + ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID);
                                                    Log.Debug("Source AREA_ID :: " + ats_wms_master_area_detailsDataTableSourceDT[0].AREA_ID);
                                                    Log.Debug("Target POSITION_ID :: " + ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID);
                                                    Log.Debug("Target RACK_ID :: " + ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID);
                                                    Log.Debug("Target FLOOR_ID :: " + ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_ID);
                                                    Log.Debug("Target AREA_ID :: " + ats_wms_master_area_detailsDataTableTargetDT[0].AREA_ID);


                                                    try
                                                    {
                                                        ats_wms_master_shift_detailsDataTableDT = ats_wms_master_shift_detailsTableAdapterInstance.GetDataByCurrentTimeDetails(0);
                                                        TimeSpan t1 = new TimeSpan(23, 59, 59);//12 am
                                                        String shiftName = "";
                                                        int shiftId = 0;
                                                        if (ats_wms_master_shift_detailsDataTableDT != null && ats_wms_master_shift_detailsDataTableDT.Count > 0)
                                                        {
                                                            Log.Debug("6.1 :: master shift ");
                                                            shiftName = ats_wms_master_shift_detailsDataTableDT[0].SHIFT_NAME;
                                                            shiftId = ats_wms_master_shift_detailsDataTableDT[0].SHIFT_ID;
                                                        }
                                                        else if (ats_wms_master_shift_detailsDataTableDT != null && ats_wms_master_shift_detailsDataTableDT.Count == 0)
                                                        {
                                                            Log.Debug("6.2 :: master shift count");
                                                            ats_wms_master_shift_detailsDataTableDT = ats_wms_master_shift_detailsTableAdapterInstance.GetDataBySHIFT_START_TIMEAndSHIFT_END_TIME();
                                                            if (ats_wms_master_shift_detailsDataTableDT != null && ats_wms_master_shift_detailsDataTableDT.Count > 0)
                                                            {
                                                                shiftName = ats_wms_master_shift_detailsDataTableDT[0].SHIFT_NAME;
                                                                shiftId = ats_wms_master_shift_detailsDataTableDT[0].SHIFT_ID;
                                                            }
                                                        }

                                                        //Inserting transfer pallet mission data
                                                        //bool conditionOne = ((ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID % 2 == 0 &&
                                                        //    ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID % 2 == 0 ) &&
                                                        //    (ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID == 6 || ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_ID == 6) ||
                                                        //    (ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID != 6 || ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_ID != 6));



                                                        try
                                                        {
                                                            conditionOne = (ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID % 2 == 0 &&
                                                                                                        ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID % 2 == 0 &&
                                                                                                        ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID <= 6 &&
                                                                                                        ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_ID <= 6);

                                                            Log.Debug("7 :: Result of Condition 1 :: " + conditionOne);

                                                        }
                                                        catch (Exception ex)
                                                        {

                                                            Log.Error("Error occured while calculating conditionOne " + ex.Message + " StackTrace " + ex.StackTrace);
                                                        }
                                                        //bool conditionTwo = ((ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID % 2 != 0
                                                        //    && ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID % 2 != 0)
                                                        //    && (ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID != 6
                                                        //    && ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_ID != 6));

                                                        try
                                                        {

                                                            conditionTwo = (ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID % 2 != 0 &&
                                                                 ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID % 2 != 0 &&
                                                                 ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID != 6 &&
                                                                 ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_ID != 6);

                                                            Log.Debug("8 :: Result of Condition 2 :: " + conditionTwo);

                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.Error("Error occured while calculating conditionTwo " + ex.Message + " StackTrace " + ex.StackTrace);
                                                        }

                                                        try
                                                        {
                                                            Log.Debug("_9 :: ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID: " + ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID+ " ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID: "+ ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID+ " ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID != 6: "+ (ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID != 6));
                                                            if (ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID % 2 == 0 && ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID % 2 == 1 && ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID != 6)
                                                            {
                                                                ats_wms_master_position_detailsDataTableTargetFrontDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_IDGreaterThanAndRACK_IDAndPOSITION_IS_ALLOCATEDAndPOSITION_IS_EMPTY(ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID, ats_wms_master_position_detailsDataTableTargetDT[0].RACK_ID, 1, 0);

                                                                conditionThree = (ats_wms_master_position_detailsDataTableTargetFrontDT != null && ats_wms_master_position_detailsDataTableTargetFrontDT.Count == 0);
                                                                if(conditionThree == false)
                                                                {
                                                                    ats_wms_master_position_detailsDataTableSourceFrontDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_IDLessThanAndRACK_IDAndPOSITION_IS_ALLOCATEDAndPOSITION_IS_EMPTY(ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID, ats_wms_master_position_detailsDataTableSourceDT[0].RACK_ID,1,0);
                                                                    conditionThreeAlternate = (ats_wms_master_position_detailsDataTableSourceFrontDT!= null && ats_wms_master_position_detailsDataTableSourceFrontDT.Count == 0);
                                                                }
                                                            }
                                                                Log.Debug("9 :: Result of Condition 3 :: " + conditionThree);
                                                            Log.Debug("9.1 :: Result of Condition 3 Alternate :: "+ conditionThreeAlternate);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.Error("Error occured while calculating conditionThree " + ex.Message + " StackTrace " + ex.StackTrace);
                                                        }


                                                        try
                                                        {
                                                            Log.Debug("_10 :: ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID: " + ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID + " ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID: " + ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID + " ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID != 6: " + (ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID != 6));
                                                            if (ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID % 2 != 0 && ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID % 2 == 0 && ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID != 6)
                                                            {
                                                                ats_wms_master_position_detailsDataTableTargetFrontDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_IDLessThanAndRACK_IDAndPOSITION_IS_ALLOCATEDAndPOSITION_IS_EMPTY(ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID, ats_wms_master_position_detailsDataTableTargetDT[0].RACK_ID, 1, 0);

                                                                conditionFour = (ats_wms_master_position_detailsDataTableTargetFrontDT != null && ats_wms_master_position_detailsDataTableTargetFrontDT.Count == 0);
                                                                if (conditionFour == false)
                                                                {
                                                                    ats_wms_master_position_detailsDataTableSourceFrontDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_IDGreaterThanAndRACK_IDAndPOSITION_IS_ALLOCATEDAndPOSITION_IS_EMPTY(ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID, ats_wms_master_position_detailsDataTableSourceDT[0].RACK_ID,1,0);
                                                                    conditionFourAlternate = (ats_wms_master_position_detailsDataTableSourceFrontDT!=null && ats_wms_master_position_detailsDataTableSourceFrontDT.Count==0);
                                                                }
                                                            }
                                                                Log.Debug("10 :: Result of Condition 4 :: " + conditionFour);
                                                            Log.Debug("10.1 :: Result of Condition 4 Alternate :: " + conditionFourAlternate);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.Error("Error occured while calculating conditionFour " + ex.Message + " StackTrace " + ex.StackTrace);
                                                        }

                                                        try
                                                        {
                                                            try
                                                            {
                                                                Log.Debug("ats_wms_master_rack_detailsDataTableSourceDT[0].RACK_ID " + ats_wms_master_rack_detailsDataTableSourceDT[0].RACK_ID + " ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID " + ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID);
                                                            }
                                                            catch (Exception ex)
                                                            {

                                                                Log.Error("Error occured while accessing RackID " + ex.Message + "StackTrace" + ex.StackTrace);
                                                            }
                                                            if (ats_wms_master_rack_detailsDataTableSourceDT[0].RACK_ID == ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID)
                                                            {
                                                                if (ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID % 2 == 0)
                                                                {
                                                                    conditionFive = true;
                                                                }
                                                            }
                                                            Log.Debug("11 :: Result of Condition 5 :: " + conditionFive);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.Error("Error occured while calculating conditionFive " + ex.Message + " StackTrace " + ex.StackTrace);
                                                        }

                                                        try
                                                        {
                                                            try
                                                            {
                                                                Log.Debug("ats_wms_master_rack_detailsDataTableSourceDT[0].RACK_ID " + ats_wms_master_rack_detailsDataTableSourceDT[0].RACK_ID + " ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID " + ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID);
                                                            }
                                                            catch (Exception ex)
                                                            {

                                                                Log.Error("Error occured while accessing RackID " + ex.Message + "StackTrace" + ex.StackTrace);
                                                            }
                                                            if (ats_wms_master_rack_detailsDataTableSourceDT[0].RACK_ID == ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID)
                                                            {
                                                                if (ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID % 2 != 0)
                                                                {
                                                                    conditionSix = true;
                                                                }
                                                            }
                                                            Log.Debug("12 :: Result of Condition 6 :: " + conditionSix);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.Error("Error occured while calculating conditionSix " + ex.Message + " StackTrace " + ex.StackTrace);
                                                        }

                                                        try
                                                        {
                                                            //var transfer_pallet = ats_wms_transfer_pallet_mission_detailsTableAdapterInstance.GetDataByPALLET_INFORMATION_IDAndIS_MISSION_GENERATED(ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID, 1);
                                                            var transfer_runtime = ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance.GetDataByPALLET_INFORMATION_IDAndTRANSFER_MISSION_STATUS1OrTRANSFER_MISSION_STATUS(ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID, "READY", "IN_PROGRESS");
                                                            if (transfer_runtime != null && transfer_runtime.Count == 0)
                                                            {

                                                                if (conditionOne || conditionThree || conditionFive || conditionFourAlternate)
                                                                {
                                                                    try
                                                                    {
                                                                        ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance.Insert(
                                                                                                                                        ats_wms_master_area_detailsDataTableTargetDT[0].AREA_ID,
                                                                                                                                    ats_wms_master_area_detailsDataTableTargetDT[0].AREA_NAME,
                                                                                                                                    (DateTime.Now).ToString(),
                                                                                                                                    ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_ID,
                                                                                                                                    ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_NAME,
                                                                                                                                    ats_wms_transfer_pallet_mission_detailsDataTableDT[i].PALLET_CODE,
                                                                                                                                    ats_wms_transfer_pallet_mission_detailsDataTableDT[i].PALLET_INFORMATION_ID,
                                                                                                                                    ats_wms_master_position_detailsDataTableTargetDT[0].ST1_POSITION_NUMBER_IN_RACK,
                                                                                                                                    ats_wms_transfer_pallet_mission_detailsDataTableDT[i].POSITION_NAME,
                                                                                                                                    ats_wms_transfer_pallet_mission_detailsDataTableDT[i].POSITION_ID,
                                                                                                                                    ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_COLUMN,
                                                                                                                                    ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID,
                                                                                                                                    ats_wms_master_rack_detailsDataTableTargetDT[0].S1_RACK_NAME,
                                                                                                                                    ats_wms_master_rack_detailsDataTableTargetDT[0].S1_RACK_SIDE,
                                                                                                                                    shiftId, shiftName, null, 0, null, "READY",
                                                                                                                                    ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID,
                                                                                                                                    ats_wms_master_position_detailsDataTableTargetDT[0].NOMENCLATURE,
                                                                                                                                    ats_wms_transfer_pallet_mission_detailsDataTableDT[i].USER_ID,
                                                                                                                                    ats_wms_transfer_pallet_mission_detailsDataTableDT[i].USER_NAME,
                                                                                                                                    ats_wms_current_stock_detailsDataTableDT[0].PRODUCT_ID,
                                                                                                                                    ats_wms_current_stock_detailsDataTableDT[0].PRODUCT_NAME,
                                                                                                                                    0,
                                                                                                                                    "NA",
                                                                                                                                    ats_wms_current_stock_detailsDataTableDT[0].CORE_SIZE,
                                                                                                                                    ats_wms_current_stock_detailsDataTableDT[0].BATCH_NUMBER,
                                                                                                                                    ats_wms_current_stock_detailsDataTableDT[0].QUANTITY, 0,
                                                                                                                                    ats_wms_current_stock_detailsDataTableDT[0].PALLET_STATUS_ID,
                                                                                                                                    ats_wms_current_stock_detailsDataTableDT[0].PALLET_STATUS_NAME,
                                                                                                                                    2
                                                                                                                                    );



                                                                        Log.Debug("Mission details inserted in transfer pallet runtime mission table:: ");

                                                                        //Update is mission generated = 1 in transfer pallet mission table
                                                                        ats_wms_transfer_pallet_mission_detailsTableAdapterInstance.UpdateIS_MISSION_GENERATEDWherePALLET_INFORMATION_ID(1, ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);
                                                                        Log.Debug("updating is mission generated equals to one in transfer mission details table");

                                                                        //Updating is transfer pallet missiuon generated in pallet information table
                                                                        ats_wms_master_pallet_informationTableAdapterInstance.UpdateIS_TRANSFER_MISSION_GENERATEDWherePALLET_INFORMATION_ID(1, ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);
                                                                        Log.Debug("updating is transfer pallet mission generated in pallet information table");

                                                                        //Updating posiition is allocated
                                                                        ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ALLOCATEDWherePOSITION_ID(1, ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Log.Error("Error occured while updating/ inserting data in DB for conditionOne || conditionThree || conditionFive " + ex.Message + " StackTrace " + ex.StackTrace);
                                                                    }


                                                                }
                                                                else if (conditionTwo || conditionFour || conditionSix || conditionThreeAlternate)
                                                                {
                                                                    try
                                                                    {
                                                                        ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance.Insert(
                                                                                                                                      ats_wms_master_area_detailsDataTableTargetDT[0].AREA_ID,
                                                                                                                                  ats_wms_master_area_detailsDataTableTargetDT[0].AREA_NAME,
                                                                                                                                  (DateTime.Now).ToString(),
                                                                                                                                  ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_ID,
                                                                                                                                  ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_NAME,
                                                                                                                                  ats_wms_transfer_pallet_mission_detailsDataTableDT[i].PALLET_CODE,
                                                                                                                                  ats_wms_transfer_pallet_mission_detailsDataTableDT[i].PALLET_INFORMATION_ID,
                                                                                                                                  ats_wms_master_position_detailsDataTableTargetDT[0].ST1_POSITION_NUMBER_IN_RACK,
                                                                                                                                  ats_wms_transfer_pallet_mission_detailsDataTableDT[i].POSITION_NAME,
                                                                                                                                  ats_wms_transfer_pallet_mission_detailsDataTableDT[i].POSITION_ID,
                                                                                                                                  ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_COLUMN,
                                                                                                                                  ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID,
                                                                                                                                  ats_wms_master_rack_detailsDataTableTargetDT[0].S1_RACK_NAME,
                                                                                                                                  ats_wms_master_rack_detailsDataTableTargetDT[0].S1_RACK_SIDE,
                                                                                                                                  shiftId, shiftName, null, 0, null, "READY",
                                                                                                                                  ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID,
                                                                                                                                  ats_wms_master_position_detailsDataTableTargetDT[0].NOMENCLATURE,
                                                                                                                                  ats_wms_transfer_pallet_mission_detailsDataTableDT[i].USER_ID,
                                                                                                                                  ats_wms_transfer_pallet_mission_detailsDataTableDT[i].USER_NAME,
                                                                                                                                  ats_wms_current_stock_detailsDataTableDT[0].PRODUCT_ID,
                                                                                                                                  ats_wms_current_stock_detailsDataTableDT[0].PRODUCT_NAME,
                                                                                                                                  0,
                                                                                                                                  "NA",
                                                                                                                                  ats_wms_current_stock_detailsDataTableDT[0].CORE_SIZE,
                                                                                                                                  ats_wms_current_stock_detailsDataTableDT[0].BATCH_NUMBER,
                                                                                                                                  ats_wms_current_stock_detailsDataTableDT[0].QUANTITY, 0,
                                                                                                                                  ats_wms_current_stock_detailsDataTableDT[0].PALLET_STATUS_ID,
                                                                                                                                  ats_wms_current_stock_detailsDataTableDT[0].PALLET_STATUS_NAME,
                                                                                                                                  1
                                                                                                                                  );

                                                                        Log.Debug("Mission details inserted in transfer pallet runtime mission table:: ");

                                                                        //Update is mission generated = 1 in transfer pallet mission table
                                                                        ats_wms_transfer_pallet_mission_detailsTableAdapterInstance.UpdateIS_MISSION_GENERATEDWherePALLET_INFORMATION_ID(1, ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);
                                                                        Log.Debug("updating is mission generated equals to one in transfer mission details table");

                                                                        //Updating is transfer pallet missiuon generated in pallet information table
                                                                        ats_wms_master_pallet_informationTableAdapterInstance.UpdateIS_TRANSFER_MISSION_GENERATEDWherePALLET_INFORMATION_ID(1, ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);
                                                                        Log.Debug("updating is transfer pallet mission generated in pallet information table");

                                                                        //Updating posiition is allocated
                                                                        ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ALLOCATEDWherePOSITION_ID(1, ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Log.Error("Error occured while updating/ inserting data in DB for conditionTwo || conditionFour || conditionSix " + ex.Message + " StackTrace " + ex.StackTrace);
                                                                    }

                                                                }

                                                                else
                                                                {
                                                                    //Log.Debug("DATA NOT FOUND IN FOLLOWING");
                                                                    //Log.Debug("Source PALLET_INFORMATION_ID :: " + ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);
                                                                    //Log.Debug("Source POSITION_ID :: " + ats_wms_master_position_detailsDataTableSourceDT[0].POSITION_ID);
                                                                    //Log.Debug("Source RACK_ID :: " + ats_wms_master_rack_detailsDataTableSourceDT[0].RACK_ID);
                                                                    //Log.Debug("Source FLOOR_ID :: " + ats_wms_master_floor_detailsDataTableSourceDT[0].FLOOR_ID);
                                                                    //Log.Debug("Source AREA_ID :: " + ats_wms_master_area_detailsDataTableSourceDT[0].AREA_ID);
                                                                    //Log.Debug("Target POSITION_ID :: " + ats_wms_master_position_detailsDataTableTargetDT[0].POSITION_ID);
                                                                    //Log.Debug("Target RACK_ID :: " + ats_wms_master_rack_detailsDataTableTargetDT[0].RACK_ID);
                                                                    //Log.Debug("Target FLOOR_ID :: " + ats_wms_master_floor_detailsDataTableTargetDT[0].FLOOR_ID);
                                                                    //Log.Debug("Target AREA_ID :: " + ats_wms_master_area_detailsDataTableTargetDT[0].AREA_ID);

                                                                    try
                                                                    {
                                                                        Log.Debug("Action on Mission not possible due to pallet in Front Position");
                                                                        ats_wms_transfer_pallet_mission_detailsTableAdapterInstance.UpdateIS_MANUAL_MISSIONWhereTRANSFER_PALLET_MISSION_DETAILS_ID(0, ats_wms_transfer_pallet_mission_detailsDataTableDT[i].TRANSFER_PALLET_MISSION_DETAILS_ID);
                                                                        Log.Debug("IsManualMIssion updated to 0");
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Log.Error("Exception occured while updating data isManualMission 0");
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Log.Debug("Mission already Generated");
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.Error("Exception occured while checking data from Transfer Runtime Table" + ex.Message + ex.StackTrace);
                                                        }

                                                    }
                                                    catch (Exception ex)
                                                    {

                                                        Log.Error("Error occured while entering shift details");
                                                    }
                                                }

                                            }
                                            catch (Exception ex)
                                            {

                                                Log.Error("transferPalletMissionDetailsOperation :: Exception occured while inserting  mission details from runtime mission dt :: " + ex.Message + " StackTrace:: " + ex.StackTrace);
                                            }

                                        }

                                    }
                                    catch (Exception ex)
                                    {

                                        Log.Error(" Exception occured while checking Transfer Management status is 0  :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                    }

                                }
                            }
                            catch (Exception ex)
                            {

                                Log.Error(" Exception occured while getting pallet information id :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                            }
                        }
                    }


                }

                catch (Exception ex)
                {

                    Log.Error(" Exception occured while checking mission generation status is 0 :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                }

            }
            catch (Exception ex)
            {

                Log.Error("startOperation :: Exception occured while stopping timer :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
            }

            finally
            {
                try
                {
                    //Starting the timer again for the next iteration
                    AtsWmsTransferPalletMissionDetailsTimer.Start();
                }
                catch (Exception ex1)
                {
                    Log.Error("startOperation :: Exception occured while stopping timer :: " + ex1.Message + " stackTrace :: " + ex1.StackTrace);
                }
            }
        }
    }

}




