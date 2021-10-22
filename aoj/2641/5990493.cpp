// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2641/judge/5990493/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

struct Obj
{
  ll x;
  ll y;
  ll z;
  ll r;
  ll l;
};

ll d(ll a, ll b, ll c) {
  return a * a + b * b + c * c;
}

int main() {
  int n, q;
  cin >> n >> q;
  vector<Obj> objs(n);
  for (var&& obj : objs) cin >> obj.x >> obj.y >> obj.z >> obj.r >> obj.l;
  for (int i = 0; i < q; i++) {
    // p1
    ll x1, y1, z1, x2, y2, z2;
    cin >> x1 >> y1 >> z1 >> x2 >> y2 >> z2;
    ll dx1 = x2 - x1, dy1 = y2 - y1, dz1 = z2 - z1;
    var len = d(dx1, dy1, dz1);
    var sqrtlen = sqrt(len);
    ll res = 0;
    for (var&& obj : objs) {
      ll dx2 = obj.x - x1, dy2 = obj.y - y1, dz2 = obj.z - z1;
      ll dx3 = obj.x - x2, dy3 = obj.y - y2, dz3 = obj.z - z2;

      if (dx1 * dx2 + dy1 * dy2 + dz1 * dz2 < 0 || 0 < dx1 * dx3 + dy1 * dy3 + dz1 * dz3) {
        if (min(d(dx2, dy2, dz2), d(dx3, dy3, dz3)) <= obj.r * obj.r) {
          // assert(false);
          // cout << "POINT INSIDE RADIUS" << endl;
        }
        continue;
      }

      var op = d(dx1 * dy2 - dy1 * dx2, dy1 * dz2 - dz1 * dy2, dz1 * dx2 - dx1 * dz2);

      if (op <= obj.r * obj.r * d(dx1, dy1, dz1)) {
        var ip = dx1 * dx2 + dy1 * dy2 + dz1 * dz2;
        var div = sqrtlen * sqrtlen;
        var xp = x1 + dx1 * ip / div, yp = y1 + dy1 * ip / div, zp = z1 + dz1 * ip / div;
        // cout << "length = " << sqrt(op) / sqrt(d(dx1, dy1, dz1)) << endl;
        // cout << "center = (" << obj.x << ", " << obj.y << ", " << obj.z << ")" << endl;
        // cout << "     p = (" << xp << ", " << yp << ", " << zp << ")" << endl;
        res += obj.l;
      }
    }
    cout << res << endl;
  }
}

