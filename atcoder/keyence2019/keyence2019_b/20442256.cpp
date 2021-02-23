// detail: https://atcoder.jp/contests/keyence2019/submissions/20442256
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  for (int i = 0; i < s.size(); i++) {
    for (int j = 0; j <= (int)s.size() - i; j++) {
      var t = s;
      if (t.erase(i, j) == "keyence") {
        cout << "YES" << endl;
        return 0;
      }
    }
  }
  cout << "NO" << endl;
}
