namespace ManagerService.Utilities
{
    public class Constants
    {
        /**
   * the Server command and the constant value
   */
        /**Command header*/
        public const string DEV_CMD_TITLE = "C:";
        /**SHELL command*/
        public const string DEV_CMD_SHELL = "SHELL {0}";
        /**CHECK*/
        public const string DEV_CMD_CHECK = "CHECK";
        /**CLEAR ATTENDANCE RECORD*/
        public const string DEV_CMD_CLEAR_LOG = "CLEAR LOG";
        /**CLEAR ATTENDANCE PHOTO*/
        public const string DEV_CMD_CLEAR_PHOTO = "CLEAR PHOTO";
        /**CLEAR ALL DATA*/
        public const string DEV_CMD_CLEAR_DATA = "CLEAR DATA";
        /**SEND DEVICE INFO TO SERVER*/
        public const string DEV_CMD_INFO = "INFO";
        /**SET DEVICE OPTION*/
        public const string DEV_CMD_SET_OPTION = "SET OPTION {0}";
        /**REBOOT DEVICE*/
        public const string DEV_CMD_REBOOT = "REBOOT";
        /**UPDATE USER INFO*/
        public const string DEV_CMD_DATA_UPDATE_USERINFO = "DATA UPDATE USERINFO PIN={0}\tName={1}\tPri={2}\tPasswd={3}\tCard={4}\tGrp={5}\tTZ={6}";
        /**UPDATE FP TEMPLATE*/
        public const string DEV_CMD_DATA_UPDATE_FINGER = "DATA UPDATE FINGERTMP PIN={0}\tFID={1}\tSize={2}\tValid={3}\tTMP={4}";
        /**UPFATE FACE TEMPLATE*/
        public const string DEV_CMD_DATA_UPDATE_FACE = "DATA UPDATE FACE PIN={0}\tFID={1}\tSize={2}\tValid={3}\tTMP={4}";
        /**UPDATE USER PHOTO*/
        public const string DEV_CMD_DATA_UPDATE_USERPIC = "DATA UPDATE USERPIC PIN={0}\tSize={1}\tContent={2}";
        /**UPDATE SMS*/
        public const string DEV_CMD_DATA_UPDATE_SMS = "DATA UPDATE SMS MSG={0}\tTAG={1}\tUID={2}\tMIN={3}\tStartTime={4}";
        /**UPDATE USER SMS*/
        public const string DEV_CMD_DATA_UPDATE_USER_SMS = "DATA UPDATE USER_SMS PIN={0}\tUID={1}";
        /**DELETE USER INFO*/
        public const string DEV_CMD_DATA_DELETE_USERINFO = "DATA DELETE USERINFO PIN={0}";
        /**DELETE FP TEMPLATE*/
        public const string DEV_CMD_DATA_DELETE_FINGER = "DATA DELETE FINGERTMP PIN={0}\tFID={1}";
        /**DELETE FACE TEMPLATE*/
        public const string DEV_CMD_DATA_DELETE_FACE = "DATA DELETE FACE PIN={0}\tFID={1}";
        /**DELETE USER PHOTO*/
        public const string DEV_CMD_DATA_DELETE_USERPIC = "DATA DELETE USERPIC PIN={0}";
        /**DELETE SMS*/
        public const string DEV_CMD_DATA_DELETE_SMS = "DATA DELETE SMS UID={0}";
        /**QUERY ATTENDANCE RECORD*/
        public const string DEV_CMD_DATA_QUERY_ATTLOG = "DATA QUERY ATTLOG StartTime={0}\tEndTime={1}";
        /**QUERY ATTENDANCE PHOTO*/
        public const string DEV_CMD_DATA_QUERY_ATTPHOTO = "DATA QUERY ATTPHOTO StartTime={0}\tEndTime={1}";
        /**QUERY USER INFO*/
        public const string DEV_CMD_DATA_QUERY_USERINFO = "DATA QUERY USERINFO PIN={0}";
        /**QUERY FP BY USER AND FINGER INDEX*/
        public const string DEV_CMD_DATA_QUERY_FINGERTMP = "DATA QUERY FINGERTMP PIN={0}\tFID={1}";
        /**QUERY FP BY USER ID*/
        public const string DEV_CMD_DATA_QUERY_FINGERTMP_ALL = "DATA QUERY FINGERTMP PIN={0}";
        /**ONLINE ENROLL USER FP*/
        public const string DEV_CMD_ENROLL_FP = "ENROLL_FP PIN={0}\tFID={1}\tRETRY={2}\tOVERWRITE={3}";
        /**CHECK AND SEND LOG*/
        public const string DEV_CMD_LOG = "LOG";
        /**UNLOCK THE DOOR*/
        public const string DEV_CMD_AC_UNLOCK = "AC_UNLOCK";
        /**CLOSE THE ALARM*/
        public const string DEV_CMD_AC_UNALARM = "AC_UNALARM";
        /**GET FILE*/
        public const string DEV_CMD_GET_FILE = "GetFile {0}";
        /**SEND FILE*/
        public const string DEV_CMD_PUT_FILE = "PutFile {0}\t{1}";
        /**RELOAD DEVICE OPTION*/
        public const string DEV_CMD_RELOAD_OPTIONS = "RELOAD OPTIONS";
        /**AUTO PROOFREAD ATTENDANCE RECORD*/
        public const string DEV_CMD_VERIFY_SUM_ATTLOG = "VERIFY SUM ATTLOG StartTime={0}\tEndTime={1}";
    }
}
