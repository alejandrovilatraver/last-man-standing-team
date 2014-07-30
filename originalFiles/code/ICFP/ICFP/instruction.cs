using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICFP
{
    public static class instruction
    {
        public static string LOAD_CONSTANT = "  LDC ";
        public static string LOAD_FROM_ENVIRONMENT = "  LD ";
        public static string ADD = "  ADD ";
        public static string SUBSTRACT = "  SUB ";
        public static string MULTIPLY = "  MUL ";
        public static string DIVIDE = "  DIV";
        public static string COMPARE_EQUAL = "  CEQ ";
        public static string COMPARE_GREATER_THAN = "  CGT ";
        public static string COMPARE_GREATER_OR_EQUAL = "  CGTE ";
        public static string TEST_IF_INTEGER = "  ATOM ";
        public static string CONS_CREATE = "  CONS ";
        public static string CONS_EXTRACT_FIRST = "  CAR ";
        public static string CONS_EXTRACT_LAST = "  CDR ";
        public static string CONDITIONAL_BRANCH = "  SEL ";
        public static string RETURN_FROM_BRANCH = "  JOIN ";
        public static string LOAD_FUNCTION = "  LDF ";
        public static string CALL_FUNCTION = "  AP ";
        public static string RETURN = "  RTN ";
        public static string CREATE_EMPTY_FRAME = "  DUM ";
        public static string CALL_FUNCTION_RECURSIVE = "  RAP ";
        public static string STOP = "  STOP ";
        public static string CONDITIONAL_BRANCH_TAIL = "  TSEL ";
        public static string CALL_FUNCTION_TAIL = "  TAP ";
        public static string CALL_FUNCTION_RECURSIVE_TAIL = "  TRAP ";
        public static string STORE_TO_ENVIRONMENT = "  ST ";
        public static string PRINTF_DEBUGGING = "  DBUG ";
        public static string BREAKPOINT_DEBUGGING = "  BRK " ;
    }

    public static class function
    {
        public static List<string> FUNCIONES = new List<string>();

        public static string PRUEBA = "prueba ";
        public static string ADD_VALUE_TO_LIST_START_2_list_value = "ADD_VALUE_TO_LIST_START_2_list_value ";
        public static string CREATE_LIST_WITH_VALUE_1_value = "CREATE_LIST_WITH_VALUE_1_value ";
        public static string OBTAIN_VALUE_FROM_A_LIST_2_index_list = "OBTAIN_VALUE_FROM_A_LIST_2_index_list ";
        public static string CREATE_TUPLE_2_value0_value1 = "CREATE_TUPLE_2_value0_value1 ";
        public static string ADD_VALUE_TO_TUPLE_START_2_tuple_value = ADD_VALUE_TO_LIST_START_2_list_value;
        public static string OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length = "OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length ";
        public static string CALCULE_STEP_2_state_world = "CALCULE_STEP_2_state_world ";
        public static string INIT_LAMBDA_MAN_1_stepFunc = "INIT_LAMBDA_MAN_1_stepFunc ";
        public static string FETCH_LAMBDAMAN_POS_1_world = "FETCH_LAMBDAMAN_POS_1_world ";
        public static string FETCH_MAP_TILE_2_position_world = "FETCH_MAP_TILE_2_position_world ";
        public static string DECIDE_MOVEMENT_FROM_WALLS_2_walls_status = "DECIDE_MOVEMENT_FROM_WALLS_2_walls_status ";
        public static string GET_VALID_DIRECTIONS_1_direction = "GET_VALID_DIRECTIONS_1_direction ";
        public static string GET_AVAILABILITY_OF_PATHS_1_world = "GET_AVAILABILITY_OF_PATHS_1_world ";
        public static string GET_SCORE_OF_AVAILABLE_PATHS_2_position_world_state = "GET_SCORE_OF_AVAILABLE_PATHS_2_availablePaths_world ";
        public static string GET_SCORE_OF_PATH_3_world_position_directions_level = "GET_SCORE_OF_PATH_3_world_directions_level ";
        public static string GET_DIRECTIONS_1_direction = "GET_DIRECTIONS_1_direction ";
        public static string GET_SCORE_OF_TILE_1_position_world = "GET_SCORE_OF_TILE_1_tileValue ";
        public static string OBTAIN_LIST_LENGTH_1_list = "OBTAIN_LIST_LENGTH_1_list ";
        public static string GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position = "GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position ";
        public static string GET_POINTS_FOR_BIFURCATIONS_1_numberOfPaths = "GET_POINTS_FOR_DIRECTIONS_1_directions ";
        public static string DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word = "DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word ";
        public static string GET_NUMBER_OF_PATHS_2_position_world = "GET_NUMBER_OF_PATHS_2_position_world ";
        public static string GET_NEW_POSITION_2_position_direction = "GET_NEW_POSITION_2_position_direction ";
        public static string SELECT_PATH_FROM_SCORES_1_scores = "SELECT_PATH_FROM_SCORES_1_scores ";
        public static string ADD_QUANTITY_IF_CURRENT_DIRECTION_3_direction_currentDirection_score = "RETURN_100_IF_CURRENT_DIRECTION_2_direction_currentDirection ";
        public static string GET_OPOSITE_DIRECTION_1_direction = "GET_OPOSITE_DIRECTION_1_direction ";

        static function()
        {
            FUNCIONES.Add(PRUEBA);
            FUNCIONES.Add(ADD_VALUE_TO_LIST_START_2_list_value);
            FUNCIONES.Add(CREATE_LIST_WITH_VALUE_1_value);
            FUNCIONES.Add(OBTAIN_VALUE_FROM_A_LIST_2_index_list);
            FUNCIONES.Add(CREATE_TUPLE_2_value0_value1);
            FUNCIONES.Add(OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length);
            FUNCIONES.Add(CALCULE_STEP_2_state_world);
            FUNCIONES.Add(INIT_LAMBDA_MAN_1_stepFunc);
            FUNCIONES.Add(FETCH_LAMBDAMAN_POS_1_world);
            FUNCIONES.Add(FETCH_MAP_TILE_2_position_world);
            FUNCIONES.Add(DECIDE_MOVEMENT_FROM_WALLS_2_walls_status);
            FUNCIONES.Add(GET_VALID_DIRECTIONS_1_direction);
            FUNCIONES.Add(GET_AVAILABILITY_OF_PATHS_1_world);
            FUNCIONES.Add(GET_SCORE_OF_AVAILABLE_PATHS_2_position_world_state);
            FUNCIONES.Add(GET_SCORE_OF_PATH_3_world_position_directions_level);
            FUNCIONES.Add(GET_DIRECTIONS_1_direction);
            FUNCIONES.Add(GET_SCORE_OF_TILE_1_position_world);
            FUNCIONES.Add(OBTAIN_LIST_LENGTH_1_list);
            FUNCIONES.Add(GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position);
            FUNCIONES.Add(GET_POINTS_FOR_BIFURCATIONS_1_numberOfPaths);
            FUNCIONES.Add(DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word);
            FUNCIONES.Add(GET_NUMBER_OF_PATHS_2_position_world);
            FUNCIONES.Add(GET_NEW_POSITION_2_position_direction);
            FUNCIONES.Add(SELECT_PATH_FROM_SCORES_1_scores);
            FUNCIONES.Add(ADD_QUANTITY_IF_CURRENT_DIRECTION_3_direction_currentDirection_score);
            FUNCIONES.Add(GET_OPOSITE_DIRECTION_1_direction);
        }
    }

    public static class branch
    {
        public static LinkedList<string> BRANCHES = new LinkedList<string>();

        public static string OBTAIN_VALUE_FROM_A_LIST_EQUAL = "obtainValueFromAListEqual ";
        public static string OBTAIN_VALUE_FROM_A_LIST_NOT_EQUAL = "obtainValueFromAListNotEqual ";
        public static string OBTAIN_VALUE_FROM_A_TUPLE_TRUE = "obtainValueFromATupleEqual ";
        public static string OBTAIN_VALUE_FROM_A_TUPLE_FALSE = "obtainValueFromATupleNotEqual ";
        public static string OBTAIN_VALUE_FROM_A_TUPLE_0 = "obtainValueFromATuple0 ";
        public static string OBTAIN_VALUE_FROM_A_TUPLE_1 = "obtainValueFromATuple1 ";
        public static string OBTAIN_VALUE_FROM_A_TUPLE_LAST_IS_2 = "obtainValueFromATupleLastIsInteger ";
        public static string OBTAIN_VALUE_FROM_A_TUPLE_LAST_IS_NOT_2 = "obtainValueFromATupleLastIsPair ";
        public static string AUTOMATIC_BRANCH = "AutomaticBranch ";

        public static int numberOfAutomaticBranches = 0;

        static branch()
        {
            BRANCHES.AddLast(OBTAIN_VALUE_FROM_A_LIST_EQUAL);
            BRANCHES.AddLast(OBTAIN_VALUE_FROM_A_LIST_NOT_EQUAL);
            BRANCHES.AddLast(OBTAIN_VALUE_FROM_A_TUPLE_TRUE);
            BRANCHES.AddLast(OBTAIN_VALUE_FROM_A_TUPLE_FALSE);
            BRANCHES.AddLast(OBTAIN_VALUE_FROM_A_TUPLE_0);
            BRANCHES.AddLast(OBTAIN_VALUE_FROM_A_TUPLE_1);
            BRANCHES.AddLast(OBTAIN_VALUE_FROM_A_TUPLE_LAST_IS_2);
            BRANCHES.AddLast(OBTAIN_VALUE_FROM_A_TUPLE_LAST_IS_NOT_2);
            BRANCHES.AddLast(AUTOMATIC_BRANCH);
        }
    }

    public static class constant
    {
    }
    
}
