// detail: https://atcoder.jp/contests/abc079/submissions/20440818
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  string s;
  cin >> s;
  vector<int> a(4);
  for (int i = 0; i < 4; i++) a[i] = s[i] - '0';
  vector<string> ops{
    "+++",
    "++-",
    "+-+",
    "+--",
    "-++",
    "-+-",
    "--+",
    "---"
  };
  for (var&& s : ops) {
    var res = a[0];
    for (int i = 0; i < 3; i++) {
      if (s[i] == '+') res += a[i + 1];
      else res -= a[i + 1];
    }
    if (res == 7) {
      cout << a[0];
      for (int i = 1; i < 4; i++) {
        cout << s[i - 1] << a[i];
      }
      cout << "=7" << endl;
      return 0;
    }
  }
}

