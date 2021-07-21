public enum EventType
{
    // examples
    SHOW_TEXT,


    // init
    ADD_UNIT,
    // time
    REAL_TIME,
    GAME_TIME,

    // fight sys
    DAMAGE_DONE,   // 伤害已经发送事件
    PRE_DAMAGE      // 将要造成伤害事件


}