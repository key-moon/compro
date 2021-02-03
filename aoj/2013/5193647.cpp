// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2013/judge/5193647/C++17
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

int parse(int h, int m, int s){
  return h * (60 * 60) + m * 60 + s;
}

using namespace std;
int main(){
  int n;
  while (cin >> n, n){
    using P = pair<int, int>;
    vector<P> v{};
    for (int i = 0; i < n; i++){
      int h, m, s; char c;
      cin >> h >> c >> m >> c >> s;
      var a = parse(h, m, s);
      cin >> h >> c >> m >> c >> s;
      var b = parse(h, m, s);
      v.emplace_back(b, -1);
      v.emplace_back(a, 1);
    }
    sort(v.begin(), v.end());
    int res = 0;
    int cur = 0;
    for (var&& [val, d] : v){
      cur += d;
      chmax(res, cur);
    }
    cout << res << endl;
  }
}

