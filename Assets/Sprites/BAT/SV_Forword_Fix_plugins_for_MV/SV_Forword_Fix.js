//=============================================================================
// SV_Forword_Fix.js
//=============================================================================

/*:
 * @plugindesc Fixed a bug that caused combat characters to retreat when moving
 * @author 安兹乌尔饭
 *
 * @help
 *在使用yep动作序列时修正战斗场景角色移动时会小退的插件
 * With yep action sequences Fixed a bug that caused combat characters to retreat when moving
 */

Sprite_Actor.prototype.refreshMotion = function() {
    var actor = this._actor;
    var motionGuard = Sprite_Actor.MOTIONS['guard'];
    if (actor) {
        if (this._motion === motionGuard && !BattleManager.isInputting()) {
                return;
        }
        var stateMotion = actor.stateMotionIndex();
        if (actor.isInputting() || actor.isActing()) {
            this.startMotion('walk');
        } else if (stateMotion === 3) {
            this.startMotion('dead');
        } else if (stateMotion === 2) {
            this.startMotion('sleep');
        } else if (actor.isChanting()) {
            this.startMotion('chant');
        } else if (actor.isGuard() || actor.isGuardWaiting()) {
            this.startMotion('guard');
        } else if (stateMotion === 1) {
            this.startMotion('abnormal');
        } else if (actor.isDying()) {
            this.startMotion('dying');
        } else if (actor.isUndecided()) {
            this.startMotion('walk');
        } else {
            this.startMotion('walk');
        }
    }
};

Sprite_Actor.prototype.stepForward = function() {
    this.startMove(0, 0, 12);
};