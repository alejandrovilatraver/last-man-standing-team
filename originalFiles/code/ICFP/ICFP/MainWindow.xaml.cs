using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ICFP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // variables that determine the lambdaman behaviour
        public static int MAX_STEPS = 10;                                               // max of steps far from lambdaman to inspect
        public static int POINTS_ADED_TO_CURRENT_DIRECTION = 102;                       // encourage the lambdaman to keep a direction 
        public static int POINTS_SUBSTRACTED_TO_OPOSITE_DIRECTION = -35;                //
        public static int POINTS_SUBSTRACTED_AT_PHANTOM = -207;                         // discourage a way if there is a ghost in it
        public static int POINTS_ADED_FOR_BIFURCATION = 11;                             // encourage a way if there is a bifurcation in it

        private static string SPACE = " ";
        private static string LINE_END = "\n";
        private static string CREATE_FUNCTION = ":";
        private static string CREATE_BRANCH = ":";


        #region create list with value(value)
        private static string CREATE_LIST_WITH_VALUE_1_value =
                CREATE_FUNCTION + function.CREATE_LIST_WITH_VALUE_1_value +
                    instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "0" + LINE_END +
                    instruction.LOAD_CONSTANT + "0" + LINE_END +
                    instruction.CONS_CREATE + LINE_END +
                    instruction.RETURN + LINE_END
                ;
        #endregion

        #region add value to list start(list, value)
        private static string ADD_VALUE_TO_LIST_START_2_list_value =
            CREATE_FUNCTION + function.ADD_VALUE_TO_LIST_START_2_list_value +
                instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "1" + LINE_END +
                instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "0" + LINE_END +
                instruction.CONS_CREATE + LINE_END +
                instruction.RETURN + LINE_END

            ;
        #endregion

        #region obtain value from a list(index, list)
        private static string OBTAIN_VALUE_FROM_A_LIST_2_index_list=
            CREATE_FUNCTION + function.OBTAIN_VALUE_FROM_A_LIST_2_index_list +
                
                
                
                instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "0" + LINE_END +
                instruction.LOAD_CONSTANT + "0" + LINE_END +
                instruction.COMPARE_EQUAL + LINE_END +
                instruction.CONDITIONAL_BRANCH + branch.OBTAIN_VALUE_FROM_A_LIST_EQUAL + SPACE + branch.OBTAIN_VALUE_FROM_A_LIST_NOT_EQUAL + LINE_END +
                instruction.RETURN +LINE_END +

                CREATE_BRANCH + branch.OBTAIN_VALUE_FROM_A_LIST_EQUAL +
                                                                                           // instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "0" + LINE_END +
                                                                                           // instruction.PRINTF_DEBUGGING + LINE_END +

                    instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "1" + LINE_END +
                    instruction.CONS_EXTRACT_FIRST + LINE_END +
                    instruction.RETURN_FROM_BRANCH + LINE_END +
                    
                CREATE_BRANCH + branch.OBTAIN_VALUE_FROM_A_LIST_NOT_EQUAL +
                                                                                           // instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "0" + LINE_END +
                                                                                           // instruction.PRINTF_DEBUGGING + LINE_END +
                    instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE +"0" +LINE_END +
                    instruction.LOAD_CONSTANT + "1" + LINE_END +
                    instruction.SUBSTRACT + LINE_END +
                                                                                           // instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "1" + LINE_END +
                                                                                           // instruction.PRINTF_DEBUGGING + LINE_END +
                    instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "1" + LINE_END +
                    instruction.CONS_EXTRACT_LAST + LINE_END +
                    instruction.LOAD_FUNCTION + function.OBTAIN_VALUE_FROM_A_LIST_2_index_list + LINE_END +
                    instruction.CALL_FUNCTION + "2"+ LINE_END +
                    instruction.RETURN_FROM_BRANCH+LINE_END
            ;
        #endregion

        #region obtain list length(list)
        private static string OBTAIN_LIST_LENGTH_1_list =
            CREATE_FUNCTION + function.OBTAIN_LIST_LENGTH_1_list +

                testIfInteger(  extractLastFromPair(loadFromEnvironment(0, 0))

                                ,
                                loadConstant(1)
                                
                                +
                                returnFromBranch()
                                ,
                                add(
                                        call(
                                                extractLastFromPair(loadFromEnvironment(0, 0))
                                                ,
                                                function.OBTAIN_LIST_LENGTH_1_list
                                            )
                                        ,
                                        loadConstant(1)
                                    )
                                    +
                                    returnFromBranch()
                                ,
                                returnFromFunction()
                             )
                ;
          private static string try_obtain_list_length=
              CREATE_FUNCTION + function.CALCULE_STEP_2_state_world +
                call(
                        call(
                                loadConstant(0)
                                ,
                                loadFromEnvironment(0,1)
                                ,
                                loadConstant(4)
                                ,

                                function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length
                            )
                        ,
                        loadConstant(0)
                        ,
                        function.OBTAIN_LIST_LENGTH_1_list
                    )
                    +
                    instruction.PRINTF_DEBUGGING + LINE_END 
                   +
                    createPair(loadConstant(0),loadConstant(0))
                    +
                    returnFromFunction()

                    
              ;

        #endregion

        #region create tuple(value0, value1)
        private static string CREATE_TUPLE_2_value0_value1=
            CREATE_FUNCTION + function.CREATE_TUPLE_2_value0_value1 + 
                instruction.LOAD_FROM_ENVIRONMENT+ "0"+ SPACE +"0"+LINE_END+
                instruction.LOAD_FROM_ENVIRONMENT+ "0" + SPACE +"1" + LINE_END+
                instruction.CONS_CREATE +LINE_END +
                instruction.RETURN + LINE_END 
            ;
        #endregion

        #region add value to tuple(tuple, value)
        private static string ADD_VALUE_TO_TUPLE_START_2_tuple_value = ADD_VALUE_TO_LIST_START_2_list_value;
        #endregion

        #region obtain value from a tuple(index, tuple, length)
        private static string OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length =

            CREATE_FUNCTION + function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length +

                                                                                                                                                           /*loadConstant(111) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                                                                           loadFromEnvironment(0, 0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                                                                           loadFromEnvironment(0, 1) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                                                                           loadFromEnvironment(0, 2) + instruction.PRINTF_DEBUGGING + LINE_END +*/
                                                                                                                                                           
                instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "0" + LINE_END +
                instruction.LOAD_CONSTANT + "1" + LINE_END +
                instruction.COMPARE_GREATER_THAN + LINE_END +
                instruction.CONDITIONAL_BRANCH + branch.OBTAIN_VALUE_FROM_A_TUPLE_TRUE + SPACE + branch.OBTAIN_VALUE_FROM_A_TUPLE_FALSE + LINE_END +

                                                                                                                                                           //loadConstant(222) + instruction.PRINTF_DEBUGGING + LINE_END +
                instruction.RETURN + LINE_END +

                CREATE_BRANCH + branch.OBTAIN_VALUE_FROM_A_TUPLE_TRUE +

                                                                                                                                                           /*loadConstant(333) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                                                                            instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "0" + LINE_END +
                                                                                                                                                            instruction.LOAD_CONSTANT + "1" + LINE_END +
                                                                                                                                                            instruction.SUBSTRACT + LINE_END +
                                                                                                                                                           instruction.PRINTF_DEBUGGING + LINE_END +

                                                                                                                                                            instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "1" + LINE_END +
                                                                                                                                                            instruction.CONS_EXTRACT_LAST + LINE_END +
                                                                                                                                                           instruction.PRINTF_DEBUGGING + LINE_END +

                                                                                                                                                            instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "2" + LINE_END +
                                                                                                                                                            instruction.LOAD_CONSTANT + "1" + LINE_END +
                                                                                                                                                            instruction.SUBSTRACT + LINE_END +
                                                                                                                                                           instruction.PRINTF_DEBUGGING + LINE_END +*/


                    instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "0" + LINE_END +
                    instruction.LOAD_CONSTANT + "1" + LINE_END +
                    instruction.SUBSTRACT + LINE_END +
                    instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "1" + LINE_END +
                    instruction.CONS_EXTRACT_LAST + LINE_END +
                    instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "2" + LINE_END +
                    instruction.LOAD_CONSTANT + "1" + LINE_END +
                    instruction.SUBSTRACT + LINE_END +
                    instruction.LOAD_FUNCTION + function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length + LINE_END +
                    instruction.CALL_FUNCTION + "3" + LINE_END +
                    instruction.RETURN_FROM_BRANCH + LINE_END +
                    
                CREATE_BRANCH + branch.OBTAIN_VALUE_FROM_A_TUPLE_FALSE +
                    instruction.LOAD_FROM_ENVIRONMENT + "0"+ SPACE + "0" + LINE_END +
                    instruction.LOAD_CONSTANT + "0" + LINE_END +
                    instruction.COMPARE_EQUAL + LINE_END + 
                    instruction.CONDITIONAL_BRANCH + branch.OBTAIN_VALUE_FROM_A_TUPLE_0 + SPACE + branch.OBTAIN_VALUE_FROM_A_TUPLE_1 + LINE_END +
                    instruction.RETURN_FROM_BRANCH +LINE_END+

                    CREATE_BRANCH + branch.OBTAIN_VALUE_FROM_A_TUPLE_0 + 
                        instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "1" + LINE_END +
                        instruction.CONS_EXTRACT_FIRST + LINE_END +
                        instruction.RETURN_FROM_BRANCH + LINE_END +

                    CREATE_BRANCH+ branch.OBTAIN_VALUE_FROM_A_TUPLE_1 +
                        instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "2" + LINE_END +
                        instruction.LOAD_CONSTANT+ "2" + LINE_END + 
                        instruction.COMPARE_EQUAL + LINE_END +
                        instruction.CONDITIONAL_BRANCH + branch.OBTAIN_VALUE_FROM_A_TUPLE_LAST_IS_2 + SPACE +branch.OBTAIN_VALUE_FROM_A_TUPLE_LAST_IS_NOT_2 + LINE_END +
                        instruction.RETURN_FROM_BRANCH + LINE_END +

                        CREATE_BRANCH + branch.OBTAIN_VALUE_FROM_A_TUPLE_LAST_IS_2 +
                            instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE+ "1" + LINE_END +
                            instruction.CONS_EXTRACT_LAST + LINE_END +
                            instruction.RETURN_FROM_BRANCH + LINE_END +

                        CREATE_BRANCH + branch.OBTAIN_VALUE_FROM_A_TUPLE_LAST_IS_NOT_2 +
                            instruction.LOAD_FROM_ENVIRONMENT + "0" + SPACE + "1" + LINE_END +
                            instruction.CONS_EXTRACT_LAST + LINE_END +
                            instruction.CONS_EXTRACT_FIRST +LINE_END +
                            instruction.RETURN_FROM_BRANCH + LINE_END 
                    ;
        #endregion


        // not used functions

        #region init lambda man(stepfunc)
        public static string INIT_LAMBDA_MAN_1_stepFunc=
                CREATE_FUNCTION + function.INIT_LAMBDA_MAN_1_stepFunc +
                    createPair(
                                loadConstant(0),
                                loadFromEnvironment(0,0))
                    +
                    returnFromFunction()
            ;
#endregion

        #region simple state calculer(state, world)
        public static string simple_state=
                CREATE_FUNCTION + function.CALCULE_STEP_2_state_world +
                    compareIfGreaterOfEqual(loadFromEnvironment(0, 0), loadConstant(8),
                                            compareIfGreaterOfEqual(loadFromEnvironment(0, 0),
                                                                        loadConstant(16)
                                                                        ,
                                                                        compareIfGreaterOfEqual(loadFromEnvironment(0, 0),
                                                                                                    loadConstant(24)
                                                                                                    ,
                                                                                                    compareIfGreaterOfEqual(loadFromEnvironment(0, 0),
                                                                                                                                loadConstant(32)
                                                                                                                                ,
                                                                                                                                createPair(loadConstant(0),
                                                                                                                                            loadConstant(0))
                                                                                                                                + returnFromBranch()
                                                                                                                                ,
                                                                                                                                createPair(add(loadFromEnvironment(0, 0), loadConstant(1)),
                                                                                                                                            loadConstant(0))
                                                                                                                                +returnFromBranch()
                                                                                                                                , returnFromBranch())
                                                                                                    ,
                                                                                                    createPair(add(loadFromEnvironment(0, 0), loadConstant(1)),
                                                                                                                loadConstant(3))
                                                                                                    + returnFromBranch()
                                                                                                    , returnFromBranch())
                                                                            
                                                                        ,
                                                                        createPair(add(loadFromEnvironment(0, 0), loadConstant(1)),
                                                                                    loadConstant(2))
                                                                        + returnFromBranch(),
                                                                        returnFromBranch())
                                            ,
                                            createPair(add(loadFromEnvironment(0, 0), loadConstant(1)),
                                                        loadConstant(1))
                                            + returnFromBranch(),
                                            returnFromFunction());
        #endregion

        #region state calculer right up left down (state, world)
        public static string right_up_left_down=
            CREATE_FUNCTION + function.CALCULE_STEP_2_state_world +
            compareIfGreater( 
                            call(   createPair(
                                                    add(    extractFirstFromPair(   
                                                                                     call(loadFromEnvironment(0, 1),
                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                        )
                                                                                )
                                                             ,
                                                             loadConstant(1)
                                                        ),

                                                            extractLastFromPair(    call(   loadFromEnvironment(0, 1),
                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                        )
                                                                                )
                                                )
                                    ,
                                    loadFromEnvironment(0,1)
                                    ,
                                    function.FETCH_MAP_TILE_2_position_world
                                )
                                
                                ,
                                loadConstant(0)
                                ,

                                createPair(loadConstant(0),loadConstant(1))+
                                returnFromBranch()
                                ,

                                compareIfGreater(
                                                    call(createPair(
                                                                                    extractFirstFromPair(call(loadFromEnvironment(0, 1),
                                                                                                                    function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                                )
                                                                                                        )
                                                                                    ,
                                                                                    substract(extractLastFromPair(
                                                                                                             call(loadFromEnvironment(0, 1),
                                                                                                                    function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                                )
                                                                                                        )
                                                                                     ,
                                                                                     loadConstant(1)
                                                                                )
                                                                        )
                                                            ,
                                                            loadFromEnvironment(0, 1)
                                                            ,
                                                            function.FETCH_MAP_TILE_2_position_world
                                                        )

                                                        ,
                                                        loadConstant(0)
                                                        ,

                                                        createPair(loadConstant(0), loadConstant(0)) +
                                                        returnFromBranch()
                                                        ,

                                                        compareIfGreater(
                                                                            call(createPair(
                                                                                                            extractFirstFromPair(call(loadFromEnvironment(0, 1),
                                                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                                                        )
                                                                                                                                )
                                                                                                            ,
                                                                                                            add(extractLastFromPair(
                                                                                                                                     call(loadFromEnvironment(0, 1),
                                                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                                                        )
                                                                                                                                )
                                                                                                                 ,
                                                                                                                 loadConstant(1)
                                                                                                             )
                                                                                                )
                                                                                    ,
                                                                                    loadFromEnvironment(0, 1)
                                                                                    ,
                                                                                    function.FETCH_MAP_TILE_2_position_world
                                                                                )

                                                                                ,
                                                                                loadConstant(0)
                                                                                ,

                                                                                createPair(loadConstant(0), loadConstant(2)) +
                                                                                returnFromBranch()
                                                                                ,

                                                                                createPair(loadConstant(0), loadConstant(3)) +
                                                                                returnFromBranch()
                                                                                ,

                                                                                returnFromBranch()


                                                                            )
                                                        ,

                                                        returnFromBranch()


                                                    )
                                ,

                                returnFromFunction()


                            )

            


            ;
        #endregion

        #region state calculer try not to stop(state, world)
        public static string try_not_to_stop=
            CREATE_FUNCTION + function.CALCULE_STEP_2_state_world +
                
                call(
                                
                                
                                call(
                                        call(
                                                call(
                                                        call (
                                                                call(createPair(
                                                                    substract(extractFirstFromPair(
                                                                                                     call(loadFromEnvironment(0, 1),
                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                        )
                                                                                                )
                                                                             ,
                                                                             loadConstant(1)
                                                                        ),

                                                                            extractLastFromPair(call(loadFromEnvironment(0, 1),
                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                        )
                                                                                                )
                                                                )
                                                                ,
                                                                loadFromEnvironment(0, 1)
                                                                ,
                                                                function.FETCH_MAP_TILE_2_position_world
                                                            )
                                                
                                                
                                                                ,
                                                                function.CREATE_LIST_WITH_VALUE_1_value
                                                             )
                                                             ,
                                                             call(createPair(
                                                                                extractFirstFromPair(call(loadFromEnvironment(0, 1),
                                                                                                                function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                            )
                                                                                                    )
                                                                                ,
                                                                                add(extractLastFromPair(
                                                                                                            call(loadFromEnvironment(0, 1),
                                                                                                                function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                            )
                                                                                                    )
                                                                                        ,
                                                                                        loadConstant(1)
                                                                                    )
                                                                                )
                                                                    ,
                                                                    loadFromEnvironment(0, 1)
                                                                    ,
                                                                    function.FETCH_MAP_TILE_2_position_world
                                                                )
                                             
                                                             ,
                                                             function.ADD_VALUE_TO_LIST_START_2_list_value
                                                     )
                                                     ,
                                                     call(createPair(
                                                                    add(extractFirstFromPair(
                                                                                                     call(loadFromEnvironment(0, 1),
                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                        )
                                                                                                )
                                                                             ,
                                                                             loadConstant(1)
                                                                        ),

                                                                            extractLastFromPair(call(loadFromEnvironment(0, 1),
                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                        )
                                                                                                )
                                                                )
                                                    ,
                                                    loadFromEnvironment(0, 1)
                                                    ,
                                                    function.FETCH_MAP_TILE_2_position_world
                                                )
                                     
                                                     ,
                                                     function.ADD_VALUE_TO_LIST_START_2_list_value
                                             )

                                             ,
                                             call(createPair(
                                                                                    extractFirstFromPair(call(loadFromEnvironment(0, 1),
                                                                                                                    function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                                )
                                                                                                        )
                                                                                    ,
                                                                                    substract(extractLastFromPair(
                                                                                                                call(loadFromEnvironment(0, 1),
                                                                                                                    function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                                )
                                                                                                        )
                                                                                        ,
                                                                                        loadConstant(1)
                                                                                )
                                                                        )
                                                                        ,
                                                                        loadFromEnvironment(0, 1)
                                                                        ,
                                                                        function.FETCH_MAP_TILE_2_position_world
                                                                    )
                                             ,
                                             function.ADD_VALUE_TO_LIST_START_2_list_value
                                     )
                                     ,
                                     loadFromEnvironment(0, 0)
                                     ,
                                     function.DECIDE_MOVEMENT_FROM_WALLS_2_walls_status
                    )+
                     
                     
                     returnFromFunction()
                     
            ;
        #endregion

        #region get availability of paths(world)
        public static string GET_AVAILABILITY_OF_PATHS_1_world =
            CREATE_FUNCTION + function.GET_AVAILABILITY_OF_PATHS_1_world +
             call(
                                        call(
                                                call(
                                                        call(
                                                                call(createPair(
                                                                    substract(extractFirstFromPair(
                                                                                                     call(loadFromEnvironment(0, 1),
                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                        )
                                                                                                )
                                                                             ,
                                                                             loadConstant(1)
                                                                        ),

                                                                            extractLastFromPair(call(loadFromEnvironment(0, 1),
                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                        )
                                                                                                )
                                                                )
                                                                ,
                                                                loadFromEnvironment(0, 1)
                                                                ,
                                                                function.FETCH_MAP_TILE_2_position_world
                                                            )


                                                                ,
                                                                function.CREATE_LIST_WITH_VALUE_1_value
                                                             )
                                                             ,
                                                             call(createPair(
                                                                                extractFirstFromPair(call(loadFromEnvironment(0, 1),
                                                                                                                function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                            )
                                                                                                    )
                                                                                ,
                                                                                add(extractLastFromPair(
                                                                                                            call(loadFromEnvironment(0, 1),
                                                                                                                function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                            )
                                                                                                    )
                                                                                        ,
                                                                                        loadConstant(1)
                                                                                    )
                                                                                )
                                                                    ,
                                                                    loadFromEnvironment(0, 1)
                                                                    ,
                                                                    function.FETCH_MAP_TILE_2_position_world
                                                                )

                                                             ,
                                                             function.ADD_VALUE_TO_LIST_START_2_list_value
                                                     )
                                                     ,
                                                     call(createPair(
                                                                    add(extractFirstFromPair(
                                                                                                     call(loadFromEnvironment(0, 1),
                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                        )
                                                                                                )
                                                                             ,
                                                                             loadConstant(1)
                                                                        ),

                                                                            extractLastFromPair(call(loadFromEnvironment(0, 1),
                                                                                                            function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                        )
                                                                                                )
                                                                )
                                                    ,
                                                    loadFromEnvironment(0, 1)
                                                    ,
                                                    function.FETCH_MAP_TILE_2_position_world
                                                )

                                                     ,
                                                     function.ADD_VALUE_TO_LIST_START_2_list_value
                                             )

                                             ,
                                             call(createPair(
                                                                                    extractFirstFromPair(call(loadFromEnvironment(0, 1),
                                                                                                                    function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                                )
                                                                                                        )
                                                                                    ,
                                                                                    substract(extractLastFromPair(
                                                                                                                call(loadFromEnvironment(0, 1),
                                                                                                                    function.FETCH_LAMBDAMAN_POS_1_world
                                                                                                                )
                                                                                                        )
                                                                                        ,
                                                                                        loadConstant(1)
                                                                                )
                                                                        )
                                                                        ,
                                                                        loadFromEnvironment(0, 1)
                                                                        ,
                                                                        function.FETCH_MAP_TILE_2_position_world
                                                                    )
                                             ,
                                             function.ADD_VALUE_TO_LIST_START_2_list_value
                                     )
                            +
                            returnFromFunction()
            ;
        #endregion


        // Functions for the definitive program

        #region state calculer choose path with more ways and less phantoms(state, world)
        public static string choose_path_more_ways_less_pantom=
            CREATE_FUNCTION + function.CALCULE_STEP_2_state_world +
                storeToEnvironment( 0,0
                                    ,
                                    call(
                                
                                                                                                                                                            //loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                        call(
                                                                                                                                                            //loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                call(
                                                                                                                                                            //loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                        loadFromEnvironment(0, 1)
                                                        ,
                                                        function.FETCH_LAMBDAMAN_POS_1_world
                                                    )

                                                                                                                                                           // +loadConstant(1) + instruction.PRINTF_DEBUGGING + LINE_END 
                                                ,
                                                loadFromEnvironment(0, 1)
                                                ,
                                                loadFromEnvironment(0,0)
                                                ,
                                                function.GET_SCORE_OF_AVAILABLE_PATHS_2_position_world_state
                                            )
                                                                                                                                                            //+ loadConstant(1) + instruction.PRINTF_DEBUGGING + LINE_END 
                                            
                                        ,
                                        function.SELECT_PATH_FROM_SCORES_1_scores
                                     )
                                    
                                  )
                                                                                                            +loadFromEnvironment(0,0) + instruction.PRINTF_DEBUGGING+LINE_END
                +
                createPair(
                                loadFromEnvironment(0,0)
                                ,
                                loadFromEnvironment(0,0)
                                                                                                                                                            //+ loadConstant(1) + instruction.PRINTF_DEBUGGING + LINE_END 
                            )
                            +
                            returnFromFunction()
                
                
            ;


        #endregion

        #region select path from scores(scores)
        public static string SELECT_PATH_FROM_SCORES_1_scores = 
            CREATE_FUNCTION + function.SELECT_PATH_FROM_SCORES_1_scores +

                                                                                                                                    loadFromEnvironment(0, 0) + instruction.PRINTF_DEBUGGING + LINE_END +

                compareIfGreater(
                                    getValueFromList(0, loadFromEnvironment(0,0))
                                    ,
                                    getValueFromList(1, loadFromEnvironment(0, 0))
                                    ,
                                    compareIfEqual(
                                                    getValueFromList(0, loadFromEnvironment(0,0))
                                                    ,
                                                    loadConstant(0)
                                                    ,
                                                    compareIfGreater(
                                                                        getValueFromList(1, loadFromEnvironment(0,0))
                                                                        ,
                                                                        getValueFromList(2, loadFromEnvironment(0,0))
                                                                        ,
                                                                        compareIfEqual(
                                                                                        getValueFromList(1, loadFromEnvironment(0,0))
                                                                                        ,
                                                                                        loadConstant(0)
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(2, loadFromEnvironment(0,0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0,0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(2, loadFromEnvironment(0,0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(1, loadFromEnvironment(0,0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0,0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(1, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(1)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(1)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        returnFromBranch()
                                                                                        )
                                                                        ,
                                                                        compareIfEqual(
                                                                                        getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                        ,
                                                                                        loadConstant(0)
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(1, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(1, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(1)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(1)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        returnFromBranch()
                                                                                        )
                                                                        ,

                                                                        returnFromBranch()
                                                                    )
                                                    ,
                                                    compareIfGreater(
                                                                        getValueFromList(0, loadFromEnvironment(0,0))
                                                                        ,
                                                                        getValueFromList(2, loadFromEnvironment(0,0))
                                                                        ,

                                                                        compareIfEqual(
                                                                                        getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                        ,
                                                                                        loadConstant(0)
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        returnFromBranch()
                                                                                        )
                                                                        ,
                                                                        compareIfEqual(
                                                                                        getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                        ,
                                                                                        loadConstant(0)
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        returnFromBranch()
                                                                                        )
                                                                        ,

                                                                        returnFromBranch()
                                                                    )
                                                    ,
                                                    returnFromBranch()
                                                )
                                    
                                    ,
                                    compareIfEqual(
                                                    getValueFromList(1, loadFromEnvironment(0, 0))
                                                    ,
                                                    loadConstant(0)
                                                    ,
                                                    compareIfGreater(
                                                                        getValueFromList(0, loadFromEnvironment(0, 0))
                                                                        ,
                                                                        getValueFromList(2, loadFromEnvironment(0, 0))
                                                                        ,

                                                                        compareIfEqual(
                                                                                        getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                        ,
                                                                                        loadConstant(0)
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        returnFromBranch()
                                                                                        )
                                                                        ,
                                                                        compareIfEqual(
                                                                                        getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                        ,
                                                                                        loadConstant(0)
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(0, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        returnFromBranch()
                                                                                        )
                                                                        ,

                                                                        returnFromBranch()
                                                                    )
                                                    ,
                                                    compareIfGreater(
                                                                        getValueFromList(1, loadFromEnvironment(0, 0))
                                                                        ,
                                                                        getValueFromList(2, loadFromEnvironment(0, 0))
                                                                        ,

                                                                        compareIfEqual(
                                                                                        getValueFromList(1, loadFromEnvironment(0, 0))
                                                                                        ,
                                                                                        loadConstant(0)
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(1, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(1, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(1)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(1)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        returnFromBranch()
                                                                                        )
                                                                        ,
                                                                        compareIfEqual(
                                                                                        getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                        ,
                                                                                        loadConstant(0)
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(1, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(1, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(1)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(1)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        compareIfGreater(
                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(2, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,
                                                                                                            compareIfEqual(
                                                                                                                            getValueFromList(3, loadFromEnvironment(0, 0))
                                                                                                                            ,
                                                                                                                            loadConstant(0)
                                                                                                                            ,
                                                                                                                            loadConstant(2)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            loadConstant(3)
                                                                                                                            +
                                                                                                                            returnFromBranch()
                                                                                                                            ,
                                                                                                                            returnFromBranch()
                                                                                                                            )
                                                                                                            ,

                                                                                                            returnFromBranch()
                                                                                                        )
                                                                                        ,
                                                                                        returnFromBranch()
                                                                                        )
                                                                        ,

                                                                        returnFromBranch()
                                                                    )
                                                    ,
                                                    returnFromBranch()
                                                )
                                    ,

                                    returnFromFunction()
                                )
            ;

        #endregion

        #region get score of available paths (position, world, state)
        public static string GET_SCORE_OF_AVAILABLE_PATHS_2_position_world_state=
            CREATE_FUNCTION + function.GET_SCORE_OF_AVAILABLE_PATHS_2_position_world_state +

                addValueToListStart(
                                        addValueToListStart(
                                                            addValueToListStart(    
                                                                                    createListWithValue(
                                                                                                                                                                //loadConstant(0)+instruction.PRINTF_DEBUGGING +LINE_END+
                                                                                                            
                                                                                                                                                                //loadConstant(1) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                                    
                                                                                                                    
                                                                                                                                                        //loadConstant(2) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                            call(
                                                                                                                    loadFromEnvironment(0,2)
                                                                                                                    ,
                                                                                                                    loadConstant(3)
                                                                                                                    ,
                                                                                                                    call(                                                       // Call function to get the score
                                                                                                                            loadFromEnvironment(0, 1)
                                                                                                                            ,
                                                                                                                            createPair(substract(extractFirstFromPair(loadFromEnvironment(0, 0)), loadConstant(1)), extractLastFromPair(loadFromEnvironment(0, 0))) // Move 1 in up direction

                                                                                                                            ,
                                                                                                                    
                                                                                                                            call(
                                                                                                                                    loadConstant(3)
                                                                                                                                    ,
                                                                                                                                    function.GET_DIRECTIONS_1_direction      // Get directions compatible with left direction
                                                                                                                                )

                                                                                                                            ,
                                                                                                                            loadConstant(MAX_STEPS)                                // max of steps


                                                                                                                            ,
                                                                                                                            function.GET_SCORE_OF_PATH_3_world_position_directions_level
                                                                                                                        )
                                                                                                                    ,
                                                                                                                    function.ADD_QUANTITY_IF_CURRENT_DIRECTION_3_direction_currentDirection_score
                                                                                                                )
                                                                                                                                                                //+loadConstant(3) + instruction.PRINTF_DEBUGGING + LINE_END 
                                                                                                                
                                                                                                        )

                                                                                    ,
                                                                                    
                                                                                                                                                                //loadConstant(4) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                                 
                                                                                            
                                                                                    call(
                                                                                            loadFromEnvironment(0,2)
                                                                                            ,
                                                                                            loadConstant(2)
                                                                                            ,
                                                                                            call(                                                       // Call function to get the score
                                                                                                    loadFromEnvironment(0, 1)
                                                                                                    ,
                                                                                                    createPair(extractFirstFromPair(loadFromEnvironment(0, 0)), add(extractLastFromPair(loadFromEnvironment(0, 0)), loadConstant(1))) // Move 1 in up direction
                                                                                                    ,
                                                                                                    call(
                                                                                                            loadConstant(2)
                                                                                                            ,
                                                                                                            function.GET_DIRECTIONS_1_direction      // Get directions compatible with down direction
                                                                                                        )

                                                                                                    ,
                                                                                                    loadConstant(MAX_STEPS)
                                                                                                    ,
                                                                                                    function.GET_SCORE_OF_PATH_3_world_position_directions_level
                                                                                                )   
                                                                                            ,
                                                                                            function.ADD_QUANTITY_IF_CURRENT_DIRECTION_3_direction_currentDirection_score
                                                                                        )
                                                                                        
                                                                                    
                                                                                )

                                                            ,
                                                            
                                                                                                      
                                                                    
                                                            call(
                                                                    loadFromEnvironment(0,2)
                                                                    ,
                                                                    loadConstant(1)
                                                                    ,
                                                                    call(                                                       // Call function to get the score
                                                                            loadFromEnvironment(0, 1)
                                                                            ,
                                                                            createPair(add(extractFirstFromPair(loadFromEnvironment(0, 0)), loadConstant(1)), extractLastFromPair(loadFromEnvironment(0, 0))) // Move 1 in up direction
                                                                            ,
                                                                            call(
                                                                                    loadConstant(1)
                                                                                    ,
                                                                                    function.GET_DIRECTIONS_1_direction      // Get directions compatible with right direction
                                                                                )
                                                                            ,
                                                                            loadConstant(MAX_STEPS)
                                                                            ,
                                                                            function.GET_SCORE_OF_PATH_3_world_position_directions_level
                                                                        )  
                                                                    ,
                                                                    function.ADD_QUANTITY_IF_CURRENT_DIRECTION_3_direction_currentDirection_score
                                                                )
                                                                
                                                            
                                                            )
                                        ,
                                        
                                                                          
                                                
                                        call(
                                                loadFromEnvironment(0,2)
                                                ,
                                                loadConstant(0)
                                                ,
                                                call(                                                       // Call function to get the score
                                                        loadFromEnvironment(0, 1)
                                                        ,
                                                        createPair(extractFirstFromPair(loadFromEnvironment(0, 0)), substract(extractLastFromPair(loadFromEnvironment(0, 0)), loadConstant(1))) // Move 1 in up direction
                                                        ,
                                                        call(
                                                                loadConstant(0)
                                                                ,
                                                                function.GET_DIRECTIONS_1_direction      // Get directions compatible with up direction
                                                            )
                                                        ,
                                                        loadConstant(MAX_STEPS)
                                                        ,
                                                        function.GET_SCORE_OF_PATH_3_world_position_directions_level
                                                     )      
                                                ,
                                                function.ADD_QUANTITY_IF_CURRENT_DIRECTION_3_direction_currentDirection_score
                                            )
                                            
                                                 
                                   )

                        +
                        returnFromFunction()

                                   
                                
            ;
        #endregion

        #region add quantity if current direction (direction,currentDirection,score)
        public static string ADD_QUANTITY_IF_CURRENT_DIRECTION_3_direction_currentDirection_score=
            CREATE_FUNCTION + function.ADD_QUANTITY_IF_CURRENT_DIRECTION_3_direction_currentDirection_score +

                compareIfEqual(
                                loadFromEnvironment(0,0)
                                                                                                                                                                //+loadConstant(10) + instruction.PRINTF_DEBUGGING + LINE_END 
                                ,
                                loadFromEnvironment(0, 1)
                                                                                                                                                                //+ loadConstant(11) + instruction.PRINTF_DEBUGGING + LINE_END
                                ,
                                compareIfEqual(
                                                 loadFromEnvironment(0,2)
                                                 ,
                                                 loadConstant(0)
                                                 ,
                                                 loadConstant(0)
                                                 +
                                                 returnFromBranch()
                                                 ,
                                                 add(
                                                        loadFromEnvironment(0,2)
                                                        ,
                                                        loadConstant(POINTS_ADED_TO_CURRENT_DIRECTION)
                                                     )
                                                 +
                                                 returnFromBranch()
                                                 ,
                                                 returnFromBranch()
                                              )
                                +
                                returnFromBranch()
                                                                                                                                                                //+ loadConstant(12) + instruction.PRINTF_DEBUGGING + LINE_END
                                
                                ,
                                compareIfEqual(
                                                    loadFromEnvironment(0,0)
                                                    ,
                                                    call(
                                                            loadFromEnvironment(0,1)
                                                            ,
                                                            function.GET_OPOSITE_DIRECTION_1_direction
                                                        )
                                                    ,
                                                    add(
                                                            loadFromEnvironment(0,2)
                                                            ,
                                                            loadConstant(POINTS_SUBSTRACTED_TO_OPOSITE_DIRECTION)
                                                        )+
                                                    returnFromBranch()
                                                    
                                                    ,
                                                    loadFromEnvironment(0,2)
                                                    +
                                                    returnFromBranch()
                                                    ,
                                                    returnFromBranch()
                                               )
                                ,
                                returnFromFunction()
                              )
            
            
           ;

        #endregion

        #region get oposite direction(direction)
        public static string GET_OPOSITE_DIRECTION_1_direction=
            CREATE_FUNCTION + function.GET_OPOSITE_DIRECTION_1_direction +
                compareIfEqual(
                                    loadFromEnvironment(0,0)
                                    ,
                                    loadConstant(0)
                                    ,
                                    loadConstant(2)
                                    +
                                    returnFromBranch()
                                    ,
                                    compareIfEqual(
                                                        loadFromEnvironment(0,0)
                                                        ,
                                                        loadConstant(1)
                                                        ,
                                                        loadConstant(3)
                                                        +
                                                        returnFromBranch()
                                                        ,
                                                        compareIfEqual(
                                                                            loadFromEnvironment(0,0)
                                                                            ,
                                                                            loadConstant(2)
                                                                            ,
                                                                            loadConstant(0)
                                                                            +
                                                                            returnFromBranch()
                                                                            ,
                                                                            loadConstant(1)
                                                                            +
                                                                            returnFromBranch()
                                                                            ,
                                                                            returnFromBranch()
                                    
                                                                      )
                                                        ,
                                                        returnFromBranch()
                                    
                                                  )
                                    ,
                                    returnFromFunction()
                                    
                              )
            ;
        #endregion


        #region get score of path(world, position, directions, level)
        public static string GET_SCORE_OF_PATH_3_world_position_directions_level=
            CREATE_FUNCTION+ function.GET_SCORE_OF_PATH_3_world_position_directions_level+

                                                                                                                                                           //loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                compareIfEqual(
                                loadFromEnvironment(0,3)
                                ,
                                loadConstant(0)
                                ,

                                                                                                                                                           //loadConstant(1) + instruction.PRINTF_DEBUGGING + LINE_END +
                                loadConstant(0)
                                +
                                returnFromBranch()

                                ,

                                                                                                                                                           //loadConstant(2) + instruction.PRINTF_DEBUGGING + LINE_END +
                                compareIfEqual(

                                                                                                                                                            //loadConstant(3) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                call(
                                                        loadFromEnvironment(0,1)
                                                        ,
                                                        loadFromEnvironment(0,0)
                                                        ,
                                                        function.FETCH_MAP_TILE_2_position_world
                                                    )
                                                ,
                                                loadConstant(0)
                                                ,

                                                                                                                                                            //loadConstant(4) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                loadConstant(0)
                                                +
                                                returnFromBranch()
                                                ,
                                                compareIfEqual(
                                                                    call(

                                                                                                                                                            //loadConstant(21) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                            call(

                                                                                    loadConstant(2)
                                                                                    ,
                                                                                    loadFromEnvironment(0, 0)
                                                                                                                                                                                                //+ loadConstant(22) + instruction.PRINTF_DEBUGGING + LINE_END 
                                                                                    ,
                                                                                    loadConstant(4)
                                                                                    ,
                                                                                    function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length

                                                                                )
                                            
                                                                                                                                                                                                //+loadConstant(22) + instruction.PRINTF_DEBUGGING + LINE_END 
                                                                            ,

                                                                            loadFromEnvironment(0,1)
                                                                            ,
                                                                            function.GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position
                                                                        )
                                                                    ,
                                                                    loadConstant(0)
                                                                    ,
                                                                    #region suma de las puntuaciones y llamada a las tres direcciones
                                                                     add(
                                                                                                                                                                                //loadConstant(5) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                            call(

                                                                                    loadFromEnvironment(0, 1)
                                                                                    ,
                                                                                    loadFromEnvironment(0, 0)
                                                                                    ,
                                                                                    function.GET_SCORE_OF_TILE_1_position_world
                                                                                )

                                                                                                                                                                                //+loadConstant(51) + instruction.PRINTF_DEBUGGING + LINE_END
                                                                            ,
                                                                            add(
                                                                                                                                                                                //loadConstant(6) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                    call(
                                                                                                                                                                                //loadConstant(61) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                            call(
                                                                                                    loadFromEnvironment(0, 1)
                                                                                                    ,
                                                                                                    loadFromEnvironment(0, 0)
                                                                                                    ,
                                                                                                    function.GET_NUMBER_OF_PATHS_2_position_world
                                                                                                )
                                                                                                                                                                                // +loadConstant(62) + instruction.PRINTF_DEBUGGING + LINE_END 
                                                                                            ,
                                                                                            function.GET_POINTS_FOR_BIFURCATIONS_1_numberOfPaths
                                                                                        )
                                                                                                                                                                                //+loadConstant(63) + instruction.PRINTF_DEBUGGING + LINE_END 
                                                                                    ,
                                                                                    add(
                                                                                                                                                                                //loadConstant(7) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                        call(
                                                                                                loadFromEnvironment(0, 0)
                                                                                                ,
                                                                                                call(
                                                                                                        loadFromEnvironment(0, 1)
                                                                                                        ,
                                                                                                        getValueFromList(0, loadFromEnvironment(0, 2))
                                                                                                        ,
                                                                                                        function.GET_NEW_POSITION_2_position_direction
                                                                                                    )
                                                                                                ,
                                                                                                                                                                                        //loadConstant(8) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                call(
                                                                                                        getValueFromList(0, loadFromEnvironment(0, 2))
                                                                                                        ,
                                                                                                        function.GET_DIRECTIONS_1_direction
                                                                                                    )
                                                                                                ,
                                                                                                                                                                                            //loadConstant(9) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                substract(
                                                                                                            loadFromEnvironment(0, 3)
                                                                                                            ,
                                                                                                            loadConstant(1)
                                                                                                            )
                                                                                                ,
                                                                                                function.GET_SCORE_OF_PATH_3_world_position_directions_level
                                                                                            )
                                                                                        ,
                                                                                        add(
                                                                                                call(
                                                                                                        loadFromEnvironment(0, 0)
                                                                                                        ,
                                                                                                        call(
                                                                                                                loadFromEnvironment(0, 1)
                                                                                                                ,
                                                                                                                getValueFromList(1, loadFromEnvironment(0, 2))
                                                                                                                ,
                                                                                                                function.GET_NEW_POSITION_2_position_direction
                                                                                                            )
                                                                                                        ,
                                                                                                                                                                                        //loadConstant(10) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                        call(
                                                                                                                getValueFromList(1, loadFromEnvironment(0, 2))
                                                                                                                ,
                                                                                                                function.GET_DIRECTIONS_1_direction
                                                                                                            )
                                                                                                            ,
                                                                                                                                                                                        //loadConstant(11) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                        substract(
                                                                                                                    loadFromEnvironment(0, 3)
                                                                                                                    ,
                                                                                                                    loadConstant(1)
                                                                                                                    )
                                                                                                        ,
                                                                                                        function.GET_SCORE_OF_PATH_3_world_position_directions_level
                                                                                                    )
                                                                                                ,
                                                                                                call(
                                                                                                        loadFromEnvironment(0, 0)
                                                                                                        ,
                                                                                                                                                                                        //loadConstant(12) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                        call(
                                                                                                                loadFromEnvironment(0, 1)
                                                                                                                ,
                                                                                                                getValueFromList(2, loadFromEnvironment(0, 2))
                                                                                                                ,
                                                                                                                function.GET_NEW_POSITION_2_position_direction
                                                                                                            )
                                                                                                        ,
                                                                                                                                                                                        //loadConstant(13) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                        call(
                                                                                                                getValueFromList(2, loadFromEnvironment(0, 2))
                                                                                                                ,
                                                                                                                function.GET_DIRECTIONS_1_direction
                                                                                                            )
                                                                                                            ,
                                                                                                        substract(
                                                                                                                    loadFromEnvironment(0, 3)
                                                                                                                    ,
                                                                                                                    loadConstant(1)
                                                                                                                    )
                                                                                                        ,
                                                                                                        function.GET_SCORE_OF_PATH_3_world_position_directions_level
                                                                                                    )
                                                                                            )
                                                                                        )
                                                                                )
                                                                        )
                                                                            #endregion
 +
                                                                    returnFromBranch()
                                                                    ,
                                                                    #region sumamos las puntuaciones y acabamos la recursion al encontrar fantasma
                                                                    add(
                                                                                                                                                                                //loadConstant(5) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                            call(

                                                                                    loadFromEnvironment(0, 1)
                                                                                    ,
                                                                                    loadFromEnvironment(0, 0)
                                                                                    ,
                                                                                    function.GET_SCORE_OF_TILE_1_position_world
                                                                                )

                                                                                                                                                                                //+loadConstant(51) + instruction.PRINTF_DEBUGGING + LINE_END
                                                                            ,
                                                                                                                                                                            //loadConstant(6) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                    call(
                                                                                                                                                                                //loadConstant(61) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                            call(
                                                                                                    loadFromEnvironment(0, 1)
                                                                                                    ,
                                                                                                    loadFromEnvironment(0, 0)
                                                                                                    ,
                                                                                                    function.GET_NUMBER_OF_PATHS_2_position_world
                                                                                                )
                                                                                                                                                                                // +loadConstant(62) + instruction.PRINTF_DEBUGGING + LINE_END 
                                                                                            ,
                                                                                            function.GET_POINTS_FOR_BIFURCATIONS_1_numberOfPaths
                                                                                        )
                                                                            )
                                                                    #endregion
                                                                    +
                                                                    returnFromBranch()
                                                                    ,
                                                                    returnFromBranch()
                                                               )
                                                
                                                +
                                                returnFromBranch()
                                                ,
                                                returnFromBranch()

                                              )
                                
                                ,

                                                                                                                                                            //loadConstant(14) + instruction.PRINTF_DEBUGGING + LINE_END +
                                returnFromFunction()
                              )
                
                
            
            ;

        #endregion

        #region get new position (position, direction)
        public static string GET_NEW_POSITION_2_position_direction=
            CREATE_FUNCTION + function.GET_NEW_POSITION_2_position_direction + 
                compareIfEqual(
                                loadFromEnvironment(0,1)
                                ,
                                loadConstant(0)
                                ,
                                createPair(
                                                extractFirstFromPair(loadFromEnvironment(0,0))
                                                ,
                                                substract(
                                                            extractLastFromPair(loadFromEnvironment(0,0))
                                                            ,
                                                            loadConstant(1)
                                                         )
                                            )
                                +
                                returnFromBranch()
                                ,
                                compareIfEqual(
                                                loadFromEnvironment(0,1)
                                                ,
                                                loadConstant(1)
                                                ,
                                                createPair(
                                                                add(
                                                                    extractFirstFromPair(loadFromEnvironment(0,0))
                                                                    ,
                                                                    loadConstant(1)
                                                                   )
                                                                ,
                                                                
                                                                 extractLastFromPair(loadFromEnvironment(0,0))
                                                            )
                                                +
                                                returnFromBranch()
                                                ,
                                                compareIfEqual(
                                                                loadFromEnvironment(0,1)
                                                                ,
                                                                loadConstant(2)
                                                                ,
                                                                createPair(
                                                                                extractFirstFromPair(loadFromEnvironment(0,0))
                                                                                ,
                                                                                add(
                                                                                            extractLastFromPair(loadFromEnvironment(0,0))
                                                                                            ,
                                                                                            loadConstant(1)
                                                                                         )
                                                                            )
                                                                +
                                                                returnFromBranch()
                                                                ,

                                                                 createPair(
                                                                                substract(
                                                                                    extractFirstFromPair(loadFromEnvironment(0,0))
                                                                                    ,
                                                                                    loadConstant(1)
                                                                                   )
                                                                                ,
                                                                
                                                                                 extractLastFromPair(loadFromEnvironment(0,0))
                                                                            )
                                                                +
                                                                returnFromBranch()
                                                                ,
                                                                returnFromBranch()

                                                              )
                                
                                                ,
                                                returnFromBranch()

                                              )
                                
                                ,
                                returnFromFunction()

                              )
                
            ;

        #endregion

        #region get points for bifurcations(numberOfPaths)
        public static string GET_POINTS_FOR_BIFURCATIONS_1_numberOfPaths = 
            CREATE_FUNCTION + function.GET_POINTS_FOR_BIFURCATIONS_1_numberOfPaths +
                compareIfGreater(
                                    loadFromEnvironment(0,0)
                                    ,
                                    loadConstant(2)
                                    ,
                                    multiply(
                                                substract(loadFromEnvironment(0,0),loadConstant(2))
                                                ,
                                                loadConstant(POINTS_ADED_FOR_BIFURCATION)
                                            )
                                    +
                                    returnFromBranch()
                                    ,
                                    loadConstant(0)
                                    +
                                    returnFromBranch()
                                    ,
                                    returnFromFunction()
                                )
            ;

        #endregion

        #region get number of paths(position, world)
        public static string GET_NUMBER_OF_PATHS_2_position_world=
            CREATE_FUNCTION + function.GET_NUMBER_OF_PATHS_2_position_world +

                                                                                                                                                          // loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                add(
                        call(
                                createPair(

                                                                                                                                                           //loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                            extractFirstFromPair(loadFromEnvironment(0,0))
                                            ,

                                                                                                                                                          // loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                            substract(

                                                                                                                                                          // loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                        extractLastFromPair(loadFromEnvironment(0,0))
                                                        ,
                                                        loadConstant(1)
                                                     )
                                            
                                                                                                                                                          // +loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END 
                                          )
                                ,
                                loadFromEnvironment(0,1)
                                ,
                                function.DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word
                            )
                            
                                                                                                                                                           //+loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END 
                        ,
                        add(

                                                                                                                                                           //loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                call(
                                        createPair(
                                                    extractFirstFromPair(loadFromEnvironment(0,0))
                                                    ,
                                                    add(
                                                                extractLastFromPair(loadFromEnvironment(0,0))
                                                                ,
                                                                loadConstant(1)
                                                             )
                                            
                                                  )
                                        ,
                                        loadFromEnvironment(0,1)
                                        ,
                                        function.DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word
                                    )
                                ,
                                add(

                                                                                                                                                           //loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                        call(
                                                createPair(
                                                            substract(
                                                                        extractFirstFromPair(loadFromEnvironment(0,0))
                                                                        ,
                                                                        loadConstant(1)
                                                                     )
                                                            ,
                                                            extractLastFromPair(loadFromEnvironment(0, 0))
                                                          )
                                                ,
                                                loadFromEnvironment(0,1)
                                                ,
                                                function.DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word
                                            )
                                        ,
                                        call(

                                                                                                                                                           //loadConstant(0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                createPair(
                                                            add(
                                                                        extractFirstFromPair(loadFromEnvironment(0, 0))
                                                                        ,
                                                                        loadConstant(1)
                                                                     )
                                                            ,
                                                            extractLastFromPair(loadFromEnvironment(0, 0))
                                                          )
                                                ,
                                                loadFromEnvironment(0, 1)
                                                ,
                                                function.DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word
                                            )
                                    )
                            )
                    )+
                    returnFromFunction()
                    
                    ;
        #endregion

        #region determine if position is not wall(position, world)
        public static string DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word=
            CREATE_FUNCTION + function.DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word +
            compareIfGreater(
                                call(
                                        loadFromEnvironment(0,0)
                                        ,
                                        loadFromEnvironment(0,1)
                                        ,
                                        function.FETCH_MAP_TILE_2_position_world
                                    )
                                ,
                                loadConstant(0)
                                ,
                                loadConstant(1)
                                +
                                returnFromBranch()
                                ,
                                loadConstant(0)
                                +
                                returnFromBranch()
                                ,
                                returnFromFunction()
                            )
            ;
        #endregion

        #region get score of tile(position, world)
        public static string GET_SCORE_OF_TILE_1_position_world =
            CREATE_FUNCTION + function.GET_SCORE_OF_TILE_1_position_world+

                call(

                                                                                                                                                            //loadConstant(21) + instruction.PRINTF_DEBUGGING + LINE_END +
                                        call(

                                                loadConstant(2)
                                                ,
                                                loadFromEnvironment(0, 1)
                                                                                                                                                            //+ loadConstant(22) + instruction.PRINTF_DEBUGGING + LINE_END 
                                                ,
                                                loadConstant(4)
                                                ,
                                                function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length

                                            )
                                            
                                                                                                                                                            //+loadConstant(22) + instruction.PRINTF_DEBUGGING + LINE_END 
                                        ,

                                        loadFromEnvironment(0,0)
                                        ,
                                        function.GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position
                                    )
                                    
                                                                                                                                                            //+loadConstant(23) + instruction.PRINTF_DEBUGGING + LINE_END 
                                    +
                                    returnFromFunction()
                
            ;
                

        #endregion 

        #region get phantom score in tile(phantomList, position)
        public static string GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position=
            CREATE_FUNCTION + function.GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position +


                                                                                                                       // loadFromEnvironment(0, 0) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                                        //getValueFromList(0, loadFromEnvironment(0, 0)) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                                                                                        //loadFromEnvironment(0,1)+ instruction.PRINTF_DEBUGGING +LINE_END+
                compareIfEqual(
                                extractFirstFromPair(
                                                                                                                        //loadConstant(0)+ instruction.PRINTF_DEBUGGING +LINE_END+
                                                        call(
                                                            loadConstant(1)
                                                            ,
                                                            getValueFromList(0,loadFromEnvironment(0,0))
                                                            ,
                                                            loadConstant(3)
                                                            ,
                                                            function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length
                                                         ))
                                                                                                                       // + loadConstant(1)+ instruction.PRINTF_DEBUGGING +LINE_END
                                ,
                                                                                                                        //loadConstant(2) + instruction.PRINTF_DEBUGGING + LINE_END +
                                extractFirstFromPair(loadFromEnvironment(0, 1))
                                                                                                                        //+ loadConstant(3) + instruction.PRINTF_DEBUGGING + LINE_END
                                ,
                                compareIfEqual(
                                                                                                                        //loadConstant(4) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                extractLastFromPair(call(
                                                                            loadConstant(1)
                                                                            ,

                                                                            getValueFromList(0, loadFromEnvironment(0, 0))
                                                                            ,
                                                                            loadConstant(3)
                                                                            ,
                                                                            function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length
                                                                         ))
                                                                                                                        //+ loadConstant(5) + instruction.PRINTF_DEBUGGING + LINE_END
                                                ,
                                                                                                                        //loadConstant(6) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                extractLastFromPair(loadFromEnvironment(0, 1))
                                                                                                                        //+ loadConstant(7) + instruction.PRINTF_DEBUGGING + LINE_END
                                                ,
                                                                                                                        //loadConstant(-100) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                loadConstant(POINTS_SUBSTRACTED_AT_PHANTOM)
                                                +
                                                returnFromBranch()
                                                                                                                        //+ loadConstant(9) + instruction.PRINTF_DEBUGGING + LINE_END
                                                ,
                                                                                                                        //loadConstant(10) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                testIfInteger(
                                                                extractLastFromPair(loadFromEnvironment(0,0))
                                                                ,
                                                                loadConstant(0)
                                                                +
                                                                returnFromBranch()
                                                                ,
                                                                call(
                                                                        extractLastFromPair(loadFromEnvironment(0, 0))
                                                                        ,
                                                                        loadFromEnvironment(0,1)
                                                                        ,
                                                                        function.GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position

                                                                    )
                                                                    +
                                                                    returnFromBranch()
                                                                ,
                                                                                                                        //loadConstant(11) + instruction.PRINTF_DEBUGGING + LINE_END+
                                                                returnFromBranch()
                                                             )
                                                ,
                                                returnFromBranch()
                                              )
                                ,
                                                                                                                        //loadConstant(12) + instruction.PRINTF_DEBUGGING + LINE_END +
                                testIfInteger(
                                                extractLastFromPair(loadFromEnvironment(0,0))
                                                ,
                                                loadConstant(0)
                                                +
                                                returnFromBranch()
                                                ,
                                                                                                                        //loadConstant(13) + instruction.PRINTF_DEBUGGING + LINE_END +
                                                call(
                                                        extractLastFromPair(loadFromEnvironment(0, 0))
                                                        ,
                                                        loadFromEnvironment(0, 1)
                                                        ,
                                                        function.GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position

                                                    )
                                                    +
                                                    returnFromBranch()
                                                                                                                        //+ loadConstant(14) + instruction.PRINTF_DEBUGGING + LINE_END
                                                ,
                                                returnFromBranch()
                                             )
                                
                                ,
                                                                                                                       // loadConstant(15)+ instruction.PRINTF_DEBUGGING +LINE_END+
                                returnFromFunction()
                              )
            ;
        #endregion

        #region get directions(direction)
        public static string GET_DIRECTIONS_1_direction=
            CREATE_FUNCTION + function.GET_DIRECTIONS_1_direction +
            
            compareIfEqual( loadFromEnvironment(0,0)
                            ,
                            loadConstant(0)
                            ,
                            addValueToListStart(addValueToListStart(createListWithValue(3), 1), 0)
                            +
                            returnFromBranch()
                            ,
                            compareIfEqual( loadFromEnvironment(0,0)
                                            ,
                                            loadConstant(1)
                                            ,
                                            addValueToListStart(addValueToListStart(createListWithValue(0), 2), 1)
                                            +
                                            returnFromBranch()
                                            ,
                                            compareIfEqual( loadFromEnvironment(0,0)
                                                            ,
                                                            loadConstant(2)
                                                            ,
                                                            addValueToListStart(addValueToListStart(createListWithValue(1), 3), 2)
                                                            +
                                                            returnFromBranch()
                                                            ,
                                                            addValueToListStart(addValueToListStart(createListWithValue(2), 0), 3)
                                                            +
                                                            returnFromBranch()
                                                            ,

                                                            returnFromBranch()
                                                           )
                                            ,

                                            returnFromBranch()
                                           )
                            ,

                            
                            returnFromFunction()
                           )


                           ;

        #endregion



        #region decide movement from walls(walls, status)
        public static string DECIDE_MOVEMENT_FROM_WALLS_2_walls_status=
            CREATE_FUNCTION + function.DECIDE_MOVEMENT_FROM_WALLS_2_walls_status +
                compareIfGreater(call(
                                        extractFirstFromPair(
                                                                call(loadFromEnvironment(0, 1)
                                                                        ,
                                                                        function.GET_VALID_DIRECTIONS_1_direction
                                                                    )

                                                            )
                                        ,
                                        loadFromEnvironment(0,0)

                                        ,
                                        function.OBTAIN_VALUE_FROM_A_LIST_2_index_list
                                      )
                                 ,
                                 loadConstant(0)
                                 ,
                                 createPair(
                                             extractFirstFromPair(
                                                                call(loadFromEnvironment(0, 1)
                                                                        ,
                                                                        function.GET_VALID_DIRECTIONS_1_direction
                                                                    )

                                                            ),
                                             extractFirstFromPair(
                                                                call(loadFromEnvironment(0, 1)
                                                                        ,
                                                                        function.GET_VALID_DIRECTIONS_1_direction
                                                                    )

                                                            )
                                             )+
                                 returnFromBranch()
                                 
                                 ,
                                 compareIfGreater(
                                                     call(
                                                            loadFromEnvironment(0,1)
                                                            ,
                                                            loadFromEnvironment(0,0)
                                                            ,
                                                            function.OBTAIN_VALUE_FROM_A_LIST_2_index_list
                                                          )
                                                       ,
                                                       loadConstant(0)
                                                       ,
                                                       createPair(
                                                                     loadFromEnvironment(0,1)
                                                                     ,
                                                                     loadFromEnvironment(0,1)
                                                                     )
                                                        +
                                                        returnFromBranch()
                                                       ,
                                                       createPair(
                                                                     extractLastFromPair(
                                                                                    call( loadFromEnvironment(0,1)
                                                                                            ,
                                                                                            function.GET_VALID_DIRECTIONS_1_direction
                                                                                        )
                                                                                    
                                                                                ),
                                                                     extractLastFromPair(
                                                                                    call( loadFromEnvironment(0,1)
                                                                                            ,
                                                                                            function.GET_VALID_DIRECTIONS_1_direction
                                                                                        )
                                                                                    
                                                                                )
                                                                     )+
                                                        returnFromBranch()
                                                        ,
                                                        returnFromBranch()
                                                     )
                                                      

                                 ,
                                 returnFromFunction()
                                 )
            ;
#endregion

        #region get valid directions(direction)
        public static string GET_VALID_DIRECTIONS_1_direction=
            CREATE_FUNCTION + function.GET_VALID_DIRECTIONS_1_direction +
            compareIfEqual( loadConstant(0)
                            ,
                            loadFromEnvironment(0,0)
                            ,
                            createPair(loadConstant(1),loadConstant(3))
                            +
                            returnFromBranch()
                            ,
                            compareIfEqual( loadConstant(1)
                                            ,
                                            loadFromEnvironment(0,0)
                                            ,
                                            createPair(loadConstant(2),loadConstant(0))+
                                            returnFromBranch()
                                            ,
                                            compareIfEqual( loadConstant(2)
                                                            ,
                                                            loadFromEnvironment(0,0)
                                                            ,
                                                            createPair(loadConstant(3),loadConstant(1))+
                                                            returnFromBranch()
                                                            ,
                                                            createPair(loadConstant(0),loadConstant(2))
                                                            +
                                                            returnFromBranch()
                                                            ,
                                                            returnFromBranch()
                                                            )
                                            ,
                                            returnFromBranch()
                                            )
                            ,
                            returnFromFunction()
                            )
            ;
        #endregion

        #region fetch lambdaman position (world)
        public static string FETCH_LAMBDAMAN_POS_1_world = 
            CREATE_FUNCTION + function.FETCH_LAMBDAMAN_POS_1_world+

            call(   loadConstant(1),

                    call(   loadConstant(1),
                            loadFromEnvironment(0,0),
                            loadConstant(4),
                            function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length),
                    loadConstant(5)
                    ,
                    
                    function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length) +
            returnFromFunction()

            ;
        #endregion

        #region fetch map tile (position, world)
        public static string FETCH_MAP_TILE_2_position_world=
            CREATE_FUNCTION+ function.FETCH_MAP_TILE_2_position_world +
            call(   extractFirstFromPair( loadFromEnvironment(0,0))
                    ,
                    call(   extractLastFromPair( loadFromEnvironment(0,0))
                            ,
                            call(   loadConstant(0)
                                    ,
                                    loadFromEnvironment(0,1)
                                    ,
                                    loadConstant(4)
                                    ,
                                    function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length
                                 ),
                            function.OBTAIN_VALUE_FROM_A_LIST_2_index_list
                         )
                    ,
                    function.OBTAIN_VALUE_FROM_A_LIST_2_index_list
                 ) +                           

             returnFromFunction()
             
            ;
        #endregion


        public static string CALCULE_STEP_2_state_world = choose_path_more_ways_less_pantom ;
        

        #region not maze prueba listas
        public static string pruebaListas=
                instruction.LOAD_CONSTANT + "0" + LINE_END +

                instruction.LOAD_CONSTANT + "3" + LINE_END +
                instruction.LOAD_FUNCTION + function.CREATE_LIST_WITH_VALUE_1_value + LINE_END +
                instruction.CALL_FUNCTION + "1" + LINE_END +

                instruction.LOAD_CONSTANT + "4" +LINE_END +
                instruction.LOAD_FUNCTION + function.ADD_VALUE_TO_LIST_START_2_list_value + LINE_END +
                instruction.CALL_FUNCTION + "2" +LINE_END +
                
                instruction.LOAD_FUNCTION + function.OBTAIN_VALUE_FROM_A_LIST_2_index_list + LINE_END + 
                instruction.CALL_FUNCTION + "2" + LINE_END +

                instruction.LOAD_CONSTANT + "0" + LINE_END +

                instruction.LOAD_CONSTANT +"7"+ LINE_END +
                instruction.LOAD_CONSTANT +"8"+ LINE_END +
                instruction.LOAD_FUNCTION + function.CREATE_TUPLE_2_value0_value1 + LINE_END +
                instruction.CALL_FUNCTION + "2" + LINE_END +

                instruction.LOAD_CONSTANT + "9" + LINE_END +
                instruction.LOAD_FUNCTION + function.ADD_VALUE_TO_TUPLE_START_2_tuple_value + LINE_END +
                instruction.CALL_FUNCTION + "2" + LINE_END +
                
                instruction.LOAD_FUNCTION + function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length + LINE_END +
                instruction.CALL_FUNCTION + "2" + LINE_END +
               
                instruction.RETURN + LINE_END +

                CREATE_LIST_WITH_VALUE_1_value +

                ADD_VALUE_TO_LIST_START_2_list_value +

                OBTAIN_VALUE_FROM_A_LIST_2_index_list +
                
                CREATE_TUPLE_2_value0_value1 +

                ADD_VALUE_TO_TUPLE_START_2_tuple_value +

                OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length
                
                ;
        #endregion

        #region not maze prueba listas con funciones
        public string pruebaListasConFunciones =
                call(loadConstant(0),
                        call(
                                call(loadConstant(3),
                                        function.CREATE_LIST_WITH_VALUE_1_value),
                                loadConstant(4),
                                function.ADD_VALUE_TO_LIST_START_2_list_value),

                        function.OBTAIN_VALUE_FROM_A_LIST_2_index_list)
                +
                call(loadConstant(0),
                        call(
                                call(loadConstant(7),
                                        loadConstant(8),
                                        function.CREATE_TUPLE_2_value0_value1),
                                loadConstant(9),
                                function.ADD_VALUE_TO_TUPLE_START_2_tuple_value),

                        function.OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length)
                +
                returnFromFunction()
                +

                CREATE_LIST_WITH_VALUE_1_value +

                ADD_VALUE_TO_LIST_START_2_list_value +

                OBTAIN_VALUE_FROM_A_LIST_2_index_list +

                CREATE_TUPLE_2_value0_value1 +

                ADD_VALUE_TO_TUPLE_START_2_tuple_value +

                OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length;
        #endregion



        #region main prueba fallida
        public string pruebaFallida = call(instruction.LOAD_FUNCTION + function.CALCULE_STEP_2_state_world + LINE_END,
                        function.INIT_LAMBDA_MAN_1_stepFunc) +
                returnFromFunction()


                +
                INIT_LAMBDA_MAN_1_stepFunc
                +
                CALCULE_STEP_2_state_world
                +
                FETCH_LAMBDAMAN_POS_1_world
                +
                FETCH_MAP_TILE_2_position_world
                +
                OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length
                +
                OBTAIN_VALUE_FROM_A_LIST_2_index_list;
        #endregion

        #region main prueba creando mundo
        public static string pruebaCreandoMundo=

                call(
                        loadConstant(0)
                        ,
                        call(
                                call(
                                        call(
                                                call(loadConstant(3),
                                                        function.CREATE_LIST_WITH_VALUE_1_value     //[3]
                                                        )
                                                ,
                                                loadConstant(4),
                                                function.ADD_VALUE_TO_LIST_START_2_list_value       //[4,3]
                                            )
                                        ,
                                        call(
                                                call(
                                                        call(loadConstant(1),
                                                                function.CREATE_LIST_WITH_VALUE_1_value //[1]
                                                             )
                                                        ,
                                                        loadConstant(2),
                                                        function.ADD_VALUE_TO_LIST_START_2_list_value//[2,1]
                                                    )

                                                ,
                                                function.CREATE_LIST_WITH_VALUE_1_value             //[[2,1]]
                                             )
                                         ,
                                         function.ADD_VALUE_TO_LIST_START_2_list_value              //[[2,1],[4,3]]
                                     )
                                ,
                                call(loadConstant(5),
                                        call(loadConstant(0),
                                                loadConstant(0),
                                                function.CREATE_TUPLE_2_value0_value1               //(0,0)
                                             ),
                                        function.CREATE_TUPLE_2_value0_value1                       //(5,(0,0))
                                    )
                                ,
                                function.CREATE_TUPLE_2_value0_value1                               //((5,(0,0)),[[4,3],[2,1]])
                            )
                        ,
                        function.CALCULE_STEP_2_state_world
                    )
                +
                returnFromFunction()
                +
                INIT_LAMBDA_MAN_1_stepFunc
                +
                CALCULE_STEP_2_state_world
                +
                FETCH_LAMBDAMAN_POS_1_world
                +
                FETCH_MAP_TILE_2_position_world
                +
                OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length
                +
                OBTAIN_VALUE_FROM_A_LIST_2_index_list
                +
                CREATE_LIST_WITH_VALUE_1_value
                +
                CREATE_TUPLE_2_value0_value1
                +
                ADD_VALUE_TO_LIST_START_2_list_value
                +
                ADD_VALUE_TO_TUPLE_START_2_tuple_value
                

                ;
        #endregion

        #region main siempre a la derecha
        public static string siempreALaDerecha=
            createPair(loadConstant(0),
                            instruction.LOAD_FUNCTION + function.CALCULE_STEP_2_state_world + LINE_END
                            ) +
                returnFromFunction()

                // Functions used
                +
                CALCULE_STEP_2_state_world
                +
                FETCH_LAMBDAMAN_POS_1_world
                +
                FETCH_MAP_TILE_2_position_world
                +
                OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length
                +
                OBTAIN_VALUE_FROM_A_LIST_2_index_list
                +
                CREATE_LIST_WITH_VALUE_1_value
                +
                ADD_VALUE_TO_LIST_START_2_list_value
                +
                DECIDE_MOVEMENT_FROM_WALLS_2_walls_status
                +
                GET_VALID_DIRECTIONS_1_direction
                ;
        #endregion

        


        public MainWindow()
        {
            InitializeComponent();
           
            // Main function

            labeledCode.Text =
                 createPair(loadConstant(0),
                            instruction.LOAD_FUNCTION + function.CALCULE_STEP_2_state_world + LINE_END
                            ) 
                +
                returnFromFunction()

                // Functions used
                +
                OBTAIN_LIST_LENGTH_1_list
                +
                CALCULE_STEP_2_state_world
                +
                FETCH_LAMBDAMAN_POS_1_world
                +
                FETCH_MAP_TILE_2_position_world
                +
                OBTAIN_VALUE_FROM_A_TUPLE_3_index_tuple_length
                +
                OBTAIN_VALUE_FROM_A_LIST_2_index_list
                +
                CREATE_LIST_WITH_VALUE_1_value
                +
                ADD_VALUE_TO_LIST_START_2_list_value
                +
                GET_SCORE_OF_AVAILABLE_PATHS_2_position_world_state
                +
                GET_SCORE_OF_PATH_3_world_position_directions_level
                +
                GET_DIRECTIONS_1_direction
                +
                GET_SCORE_OF_TILE_1_position_world
                 +
                GET_PHANTOM_SCORE_IN_TILE_2_phantomList_position
                +
                GET_POINTS_FOR_BIFURCATIONS_1_numberOfPaths
                +
                DETERMINE_IF_POSITION_IS_NOT_WALL_2_position_word
                +
                GET_NUMBER_OF_PATHS_2_position_world 
                +
                GET_NEW_POSITION_2_position_direction 
                +
                SELECT_PATH_FROM_SCORES_1_scores 
                +
                ADD_QUANTITY_IF_CURRENT_DIRECTION_3_direction_currentDirection_score
                +
                GET_OPOSITE_DIRECTION_1_direction
                ;




            code.Text = sustituirFunciones();

            
        }


        #region label change function
        public string sustituirFunciones()
        {
            string codeWithLabels=labeledCode.Text;
            List<int> functionPositions = new List<int>();
            List<string> functionNames = new List<string>();
            foreach (string func in function.FUNCIONES)
            {
                int definicion = codeWithLabels.IndexOf(CREATE_FUNCTION + func);
                if (definicion > 0)
                {
                    int numeroDeLinea = 0;
                    for (int i = 0; i < definicion; i++)
                    {
                        if (codeWithLabels[i] == '\n')
                        {
                            numeroDeLinea++;
                        }
                    }
                    functionPositions.Add(numeroDeLinea);
                    functionNames.Add(func);
                    codeWithLabels=codeWithLabels.Replace(CREATE_FUNCTION + func, "");
                    codeWithLabels = codeWithLabels.Replace(func, Convert.ToString(numeroDeLinea)+"    ;call "+func);
                }
            }

            List<int> branchPositions = new List<int>();
            List<string> branchNames = new List<string>();
            foreach (string bra in branch.BRANCHES)
            {
                int definicion = codeWithLabels.IndexOf(CREATE_BRANCH + bra);
                if (definicion > 0)
                {
                    int numeroDeLinea = 0;
                    for (int i = 0; i < definicion; i++)
                    {
                        if (codeWithLabels[i] == '\n')
                        {
                            numeroDeLinea++;
                        }
                    }
                    branchPositions.Add(numeroDeLinea);
                    branchNames.Add(bra);
                    codeWithLabels=codeWithLabels.Replace(CREATE_BRANCH + bra, "");
                    codeWithLabels = codeWithLabels.Replace(bra, Convert.ToString(numeroDeLinea));
                }
            }
            
            int lineNumber = 0;

            for (int i = 0; i < codeWithLabels.Length; i++)
            {
                
                if (codeWithLabels[i] == '\n')
                {
                    string insertion="       ;"+Convert.ToString(lineNumber);
                    
                    if (functionPositions.IndexOf(lineNumber) >= 0)
                    {
                        insertion += "  " + functionNames[functionPositions.IndexOf(lineNumber)].ToUpper();
                    }
                    
                    if (branchPositions.IndexOf(lineNumber) >= 0)
                    {
                        insertion += "  " + branchNames[branchPositions.IndexOf(lineNumber)];
                    }
                    
                    codeWithLabels=codeWithLabels.Insert(i, insertion);
                    i += insertion.Length;
                    lineNumber++;
                }
            }

            return codeWithLabels;
        }
        #endregion

        #region helper functions




        public static string loadConstant(int constant)
        {
            return instruction.LOAD_CONSTANT + Convert.ToInt32(constant) + LINE_END;
        }

        public static string loadFromEnvironment(int environment, int variable)
        {
            return instruction.LOAD_FROM_ENVIRONMENT + Convert.ToInt32(environment) + SPACE + Convert.ToInt32(variable) + LINE_END;
        }

        public static string add(string firstValue, string secondValue)
        {
            return firstValue + secondValue +instruction.ADD+LINE_END;
        }
        public static string createPair(string firstComponent, string secondComponent)
        {
            return firstComponent+
                secondComponent+
                instruction.CONS_CREATE + LINE_END;
        }
        public static string substract(string firstValue, string secondValue)
        {
            return firstValue + secondValue + instruction.SUBSTRACT+LINE_END;
        }
        public static string multiply(string firstValue, string secondValue)
        {
            return firstValue + secondValue + instruction.MULTIPLY + LINE_END;
        }
        public static string divide(string firstValue, string secondValue)
        {
            return firstValue + secondValue + instruction.DIVIDE + LINE_END;
        }
        public static string testIfInteger(string value,string trueBranch, string falseBranch, string Ending){
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9,Convert.ToString(1)));
            string trueBranchLabel = branch.BRANCHES.Last();
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string falseBranchLabel = branch.BRANCHES.Last();
            return  value + 
                    instruction.TEST_IF_INTEGER+ LINE_END +
                    instruction.CONDITIONAL_BRANCH +trueBranchLabel + SPACE +falseBranchLabel + LINE_END +
                    Ending +
                        CREATE_BRANCH + trueBranchLabel +
                        trueBranch +
                        CREATE_BRANCH + falseBranchLabel +
                        falseBranch;
        }
        public static string compareIfEqual(string firstValue, string secondValue,string trueBranch, string falseBranch, string Ending)
        {

            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9,Convert.ToString(1)));
            string trueBranchLabel = branch.BRANCHES.Last();
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string falseBranchLabel = branch.BRANCHES.Last();
            return firstValue + 
                    secondValue + 
                    instruction.COMPARE_EQUAL+ LINE_END +
                    instruction.CONDITIONAL_BRANCH +trueBranchLabel + SPACE +falseBranchLabel + LINE_END +
                    Ending +
                        CREATE_BRANCH + trueBranchLabel +
                        trueBranch +
                        CREATE_BRANCH + falseBranchLabel +
                        falseBranch;
        }
        public static string compareIfGreater(string firstValue, string secondValue, string trueBranch, string falseBranch, string Ending)
        {
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string trueBranchLabel = branch.BRANCHES.Last();
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string falseBranchLabel = branch.BRANCHES.Last();
            return firstValue +
                    secondValue +
                    instruction.COMPARE_GREATER_THAN + LINE_END +
                    instruction.CONDITIONAL_BRANCH + trueBranchLabel + SPACE + falseBranchLabel + LINE_END +
                    Ending +
                    CREATE_BRANCH+trueBranchLabel+
                        trueBranch +
                    CREATE_BRANCH+falseBranchLabel+
                        falseBranch;
        }
        public static string compareIfGreaterOfEqual(string firstValue, string secondValue, string trueBranch, string falseBranch, string Ending)
        {
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string trueBranchLabel = branch.BRANCHES.Last();
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string falseBranchLabel = branch.BRANCHES.Last();
            return firstValue +
                    secondValue +
                    instruction.COMPARE_GREATER_OR_EQUAL + LINE_END +
                    instruction.CONDITIONAL_BRANCH + trueBranchLabel + SPACE + falseBranchLabel + LINE_END +
                    Ending +
                    CREATE_BRANCH + trueBranchLabel +
                        trueBranch +
                    CREATE_BRANCH + falseBranchLabel +
                        falseBranch;
        }
        public static string compareIfEqualTail(string firstValue, string secondValue, string trueBranch, string falseBranch, string Ending)
        {
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string trueBranchLabel = branch.BRANCHES.Last();
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string falseBranchLabel = branch.BRANCHES.Last();
            return firstValue +
                    secondValue +
                    instruction.COMPARE_EQUAL + LINE_END +
                    instruction.CONDITIONAL_BRANCH_TAIL + trueBranchLabel + SPACE + falseBranchLabel + LINE_END +
                    Ending +
                    CREATE_BRANCH + trueBranchLabel +
                        trueBranch +
                    CREATE_BRANCH + falseBranchLabel +
                        falseBranch;
        }
        public static string compareIfGreaterTail(string firstValue, string secondValue, string trueBranch, string falseBranch, string Ending)
        {
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string trueBranchLabel = branch.BRANCHES.Last();
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string falseBranchLabel = branch.BRANCHES.Last();
            return firstValue +
                    secondValue +
                    instruction.COMPARE_GREATER_THAN + LINE_END +
                    instruction.CONDITIONAL_BRANCH_TAIL + trueBranchLabel + SPACE + falseBranchLabel + LINE_END +
                    Ending +
                    CREATE_BRANCH + trueBranchLabel +
                        trueBranch +
                    CREATE_BRANCH + falseBranchLabel +
                        falseBranch;
        }
        public static string compareIfGreaterOfEqualTail(string firstValue, string secondValue, string trueBranch, string falseBranch, string Ending)
        {
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string trueBranchLabel = branch.BRANCHES.Last();
            branch.BRANCHES.AddLast(branch.BRANCHES.Last().Insert(9, Convert.ToString(1)));
            string falseBranchLabel = branch.BRANCHES.Last();
            return firstValue +
                    secondValue +
                    instruction.COMPARE_GREATER_OR_EQUAL + LINE_END +
                    instruction.CONDITIONAL_BRANCH_TAIL + trueBranchLabel + SPACE + falseBranchLabel + LINE_END +
                    Ending +
                    CREATE_BRANCH + trueBranchLabel +
                        trueBranch +
                    CREATE_BRANCH + falseBranchLabel +
                        falseBranch;
        }
        public static string returnFromBranch()
        {
            return instruction.RETURN_FROM_BRANCH + LINE_END;
        }
        public static string call(string parameter , string functionToLoad)
        {
            return parameter +
                instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                instruction.CALL_FUNCTION + "1" +LINE_END;
        }
        public static string call( string parameter1, string parameter2 , string functionToLoad)
        {
            return parameter1 +
                parameter2 +
                instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                instruction.CALL_FUNCTION + "2" + LINE_END;
        }
        public static string call(string parameter1, string parameter2, string parameter3, string functionToLoad)
        {
            return parameter1 +
                parameter2 +
                parameter3+
                instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                instruction.CALL_FUNCTION + "3" + LINE_END;
        }
        public static string call(string parameter1, string parameter2, string parameter3, string parameter4, string functionToLoad)
        {
            return parameter1 +
                parameter2 +
                parameter3 +
                parameter4 +
                instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                instruction.CALL_FUNCTION + "4" + LINE_END;
        }
        public static string callTail(string parameter, string functionToLoad)
        {
            return parameter +
                instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                instruction.CALL_FUNCTION_TAIL + "1" + LINE_END;
        }
        public static string callTail(string parameter1, string parameter2, string functionToLoad)
        {
            return parameter1 +
                parameter2 +
                instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                instruction.CALL_FUNCTION_TAIL + "2" + LINE_END;
        }
        public static string returnFromFunction()
        {
            return instruction.RETURN + LINE_END;
        }
        public static string callRecursive(string parameter, string functionToLoad)
        {
            return instruction.CREATE_EMPTY_FRAME + "1" + LINE_END +
                   parameter +
                   instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                   instruction.CALL_FUNCTION_RECURSIVE + "1" + LINE_END;
        }
        public static string callRecursive(string parameter1, string parameter2, string functionToLoad)
        {
            return instruction.CREATE_EMPTY_FRAME + "2" + LINE_END +
                   parameter1 +
                   parameter2 +
                   instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                   instruction.CALL_FUNCTION_RECURSIVE + "2" + LINE_END;
        }
        public static string callRecursiveTail(string parameter, string functionToLoad)
        {
            return instruction.CREATE_EMPTY_FRAME + "1" + LINE_END +
                   parameter +
                   instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                   instruction.CALL_FUNCTION_RECURSIVE_TAIL + "1" + LINE_END;
        }
        public static string callRecursiveTail(string parameter1, string parameter2, string functionToLoad)
        {
            return instruction.CREATE_EMPTY_FRAME + "2" + LINE_END +
                   parameter1 +
                   parameter2 +
                   instruction.LOAD_FUNCTION + functionToLoad + LINE_END +
                   instruction.CALL_FUNCTION_RECURSIVE_TAIL + "2" + LINE_END;
        }
        public static string stop()
        {
            return instruction.STOP+LINE_END;
        }
        public static string storeToEnvironment(int environment, int variable, string value)
        {

            return  value 
                    +
                    instruction.STORE_TO_ENVIRONMENT + Convert.ToString(environment) + SPACE + Convert.ToString(variable) + LINE_END;
        }

        public static string extractLastFromPair(string pair)
        {
            return pair +
                    instruction.CONS_EXTRACT_LAST + LINE_END;
        }
        public static string extractFirstFromPair(string pair)
        {
            return pair +
                    instruction.CONS_EXTRACT_FIRST + LINE_END;
        }
        public static string getValueFromList(int index, string list)
        {
            return call(    loadConstant(index)
                            ,
                            list
                            ,
                            function.OBTAIN_VALUE_FROM_A_LIST_2_index_list
                       );
        }

        public static string createListWithValue(int value)
        {

            return call(
                                                                    loadConstant(value)
                                                                    ,
                                                                    function.CREATE_LIST_WITH_VALUE_1_value
                                                                );
        }

        public static string createListWithValue(string value)
        {
            return call(
                                                                    value
                                                                    ,
                                                                    function.CREATE_LIST_WITH_VALUE_1_value
                                                                );
        }
        public static string addValueToListStart(string list, int value)
        {
            return call(
                                                            list
                                                            ,
                                                            loadConstant(value)
                                                            ,
                                                            function.ADD_VALUE_TO_LIST_START_2_list_value
                                                        );
        }
        public static string addValueToListStart(string list, string value)
        {
            return call(
                                                            list
                                                            ,
                                                            value
                                                            ,
                                                            function.ADD_VALUE_TO_LIST_START_2_list_value
                                                        );
        }
        #endregion






    }

    
}
