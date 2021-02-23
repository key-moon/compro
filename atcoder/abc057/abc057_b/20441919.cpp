// detail: https://atcoder.jp/contests/abc057/submissions/20441919
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m;
  cin >> n >> m;
  using P = pair<ll, ll>;
  var d = [](P a, P b) { return abs(a.first - b.first) + abs(a.second - b.second); };
  vector<P> a(n);
  for (int i = 0; i < n; i++) cin >> a[i].first >> a[i].second;
  vector<P> b(m);
  for (int i = 0; i < m; i++) cin >> b[i].first >> b[i].second;
  for (int i = 0; i < n; i++) {
    int ind = 0;
    int mn = INT_MAX; 
    var p1 = a[i];
    int j = 0;
    for (var&& p2 : b) {
      var dist = d(p1, p2);
      if (dist < mn) {
        mn = dist;
        ind = j + 1;
      }
      j++;
    }
    cout << ind << endl;
  }

}
