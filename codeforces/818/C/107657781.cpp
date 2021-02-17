// detail: https://codeforces.com/contest/818/submission/107657781
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
  using P = pair<int, int>;
  int n;
  cin >> n;
  int H, W;
  cin >> H >> W;
  vector<P> xInfo{};
  vector<P> yInfo{};
  vector<int> type{};
  for (int i = 1; i <= n; i++) {
    int x1, y1, x2, y2;
    cin >> x1 >> y1 >> x2 >> y2;
    if (x1 > x2) swap(x1, x2);
    if (y1 > y2) swap(y1, y2);
    type.emplace_back(x1 == x2 ? -1 : 1);
    xInfo.emplace_back(x1, i);
    xInfo.emplace_back(x2, -i);
    yInfo.emplace_back(y1, i);
    yInfo.emplace_back(y2, -i);
  }
  sort(xInfo.begin(), xInfo.end());
  sort(yInfo.begin(), yInfo.end());
  var f = [&](vector<P>& info, int ind, int dir) {
    vector<int> res(n);
    int cnt = 0;
    for (int i = ind; 0 <= i && i < (int)info.size(); i += dir) {
      if (0 < info[i].second * dir) cnt++;
      else {
        res[abs(info[i].second) - 1] = cnt;
      }
    }
    return res;
  };
  var resL = f(xInfo, 0, 1);
  var resR = f(xInfo, (int)xInfo.size() - 1, -1);
  var resU = f(yInfo, 0, 1);
  var resD = f(yInfo, (int)yInfo.size() - 1, -1);
  int l, r, u, d;
  cin >> l >> r >> u >> d;
  for (int i = 0; i < n; i++) {
    if (type[i] == -1) {
      resU[i]--; resD[i]--;
    }
    else {
      resL[i]--; resR[i]--;
    }
    if (resL[i] == l &&
        resR[i] == r &&
        resU[i] == u &&
        resD[i] == d) {
      cout << i + 1 << endl;
      return 0;
    }
  }
  cout << -1 << endl;
}
