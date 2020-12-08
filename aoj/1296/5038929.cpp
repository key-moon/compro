// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1296/judge/5038929/C++17
// copied from http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=4437114

#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

using namespace std;

bool solve(){
    int n;
    cin >> n;
    if (n == 0) return false;
    vector<string> a(n);
    vector<string> b(n);
    for (int i = 0; i < n; i++){
        cin >> a[i] >> b[i];
    }
    string s, t;
    cin >> s >> t;
    if (s == t){
        cout << 0 << endl;
        return true;
    }
    unordered_set<string> se{t};
    vector<string> prev{t};
    for (int ctr = 1; ; ctr++){
        if (prev.size() == 0){
            cout << -1 << endl;
            return true;
        }
        vector<string> next{};
        for (auto&& curstr : prev){
            //cout << curstr << endl;
            for (int i = 0; i < n; i++){
                //generate next strings
                vector<string> beforereplace{curstr};
                for (int j = 0; j <= ((int)curstr.size()) - ((int)b[i].size()); j++){
                    if (curstr.substr(j, b[i].size()) == b[i]){
                        var tmp = beforereplace;
                        for (auto&& str : beforereplace){
                            if (str[j] == '#') continue;
                            var tmpstr = str;
                            for (int k = j; k < j + b[i].size(); k++){
                                tmpstr[k] = '#';
                            }
                            tmp.push_back(tmpstr);
                        }
                        beforereplace = move(tmp);
                    }
                }

                for (auto&& str : beforereplace){
                    for (int j = 0; j < str.size(); j++){
                        if (str[j] == '#') {
                            str.replace(j, b[i].size(), a[i]);
                            j += a[i].size() - 1;
                        }
                    }

                    string verify = "";
                    for (int j = 0; j < str.size(); j++){
                        if (j + a[i].size() <= str.size() && str.substr(j, a[i].size()) == a[i]){
                            verify += b[i];
                            j += a[i].size() - 1;
                        }
                        else verify += str[j];
                    }

                    if (verify != curstr) {
                        goto end;
                    }
                    if (str == s) {
                        cout << ctr << endl;
                        return true;
                    }
                    if (se.insert(str).second) next.push_back(str);
                    end:;
                }
            }
        }
        prev = move(next);
    }
}


signed main(){
    while (solve());
}

