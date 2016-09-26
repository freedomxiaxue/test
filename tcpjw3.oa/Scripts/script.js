var _devEventClass = function () { };
var devEvent;

_devEventClass.prototype._grid = '';

_devEventClass.prototype.fullScreen = function (s, e) {
    window.grid = this._grid;
    if (typeof (s) === 'object' && typeof (this._grid) === 'object')
        this._grid.SetHeight(s.GetPaneByName('MainPane').GetClientHeight());
}

_devEventClass.prototype.setFullScreen = function (_grid) {
    this._grid = _grid;
};
devEvent = new _devEventClass();